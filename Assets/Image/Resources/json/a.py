#!/usr/bin/python
# -*- coding: utf-8 -*-
import json
import os
filenames = ["DeaSword","TaeSword","B_M_Sword","Helmet","L_Armor","NCL","BU","hea","bod","hand"]

for filename in filenames:
    if filename <> "bod":
        continue
    if not os.path.exists('%s.json'%filename):
        print 'no'
    with open('%s.json'%filename,'r') as fp:
        ss = json.loads(fp.read())
    price_limit = 1000
    for s in ss:
        s['HP'] = 10
        s['price'] = price_limit
        price_limit += 3000

    ss[0]['name'] = 'Bagic Wing'
    ss[0]['def'] = 20
    ss[0]['HP'] = 5
    ss[1]['name'] = 'Angel Wing'
    ss[1]['def'] = 10
    ss[1]['HP'] = 30
    ss[2]['name'] = 'White Wing'
    ss[2]['def'] = 15
    ss[2]['HP'] = 50
    ss[3]['name'] = 'Big Angel Wing'
    ss[3]['def'] = 20
    ss[3]['HP'] = 150
    print ss[0]['name']
    with open('%s.json'%filename,'w') as fp:
        fp.write(json.dumps(ss))
