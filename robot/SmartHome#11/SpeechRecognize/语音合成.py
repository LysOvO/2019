#!/usr/bin/python
#-*-coding:utf-8 -*-



from aip import AipSpeech    
import os

APP_ID = '16644104'
API_KEY = 'Xkv8GDTPnPphP6j1AdPt6H9L'
SECRET_KEY = 'Gj8D8LNDDR7iqgHwZ0IiIbgQImoiBK7r'

client = AipSpeech(APP_ID, API_KEY, SECRET_KEY)
#AipSpeech.setConnectionTimeoutInMillis(10)   timeout! 10(s)
a ='�����ѹر�'
#b ='�ص�' ���ѹر� �����ѹر�
#c ='���ڴ򿪷���'
#d ='�رշ���'
#e ='�򿪴���'
#f ='�رմ���'


print(type(a))
print(a)
#
result  = client.synthesis(a, 'zh', 1, {
    'vol': 5,
    'per': 0,
    'spd': 5,
    
})

# 
if not isinstance(result, dict):
    with open('./sound/combine.mp3', 'wb') as f:
        f.write(result)

print('play the mp3...')
#os.system("./sound/combine.mp3")