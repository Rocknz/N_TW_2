#!/usr/bin/python
# -*- coding: utf-8 -*-
import json
import os
filenames = ["DeaSword","TaeSword","B_M_Sword","Helmet","L_Armor","NCL","BU","hea","bod","hand"]

for filename in filenames:
    if filename <> "hea":
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

    ss[0]['hack_damage'] = 1
    ss[0]['int_damage'] = 2
    ss[1]['hack_damage'] = 2
    ss[1]['int_damage'] = 3
    ss[2]['hack_damage'] = 3
    ss[2]['int_damage'] = 4
    ss[3]['hack_damage'] = 5
    ss[3]['int_damage'] = 5
    print ss[0]['name']
    with open('%s.json'%filename,'w') as fp:
        fp.write(json.dumps(ss))
