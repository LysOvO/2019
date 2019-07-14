#AipSpeech
import pyaudio
import wave
import os
import sys
from aip import AipSpeech


print('4')

targetPath = os.getcwd() + os.path.sep + 'sound'
print (targetPath)
if not os.path.exists(targetPath):
    os.makedirs(targetPath)
    print('makdir sound')
else:
    print('the path exit')



# get .pcm
##############################

CHUNK = 1024
FORMAT = pyaudio.paInt16
CHANNELS = 1
RATE = 16000
RECORD_SECONDS = 4
WAVE_OUTPUT_FILENAME = "./sound/output.pcm"


#os.close(sys.stderr.fileno())

print('p=pyaudio')
p = pyaudio.PyAudio()
print('get pyaudio')

stream = p.open(format=FORMAT,
                channels=CHANNELS,
                rate=RATE,
                input=True,
                frames_per_buffer=CHUNK)

print("recording...")

frames = []

for i in range(0, int(RATE / CHUNK * RECORD_SECONDS)):
    data = stream.read(CHUNK)
    frames.append(data)

#print("done")

stream.stop_stream()
stream.close()
p.terminate()

wf = wave.open(WAVE_OUTPUT_FILENAME, 'wb')
wf.setnchannels(CHANNELS)
wf.setsampwidth(p.get_sample_size(FORMAT))
wf.setframerate(RATE)
wf.writeframes(b''.join(frames))
wf.close()

############################




"""  APPID AK SK """
APP_ID = '16644104'
API_KEY = 'Xkv8GDTPnPphP6j1AdPt6H9L'
SECRET_KEY = 'Gj8D8LNDDR7iqgHwZ0IiIbgQImoiBK7r'

client = AipSpeech(APP_ID, API_KEY, SECRET_KEY)


def get_file_content(filePath):
    with open(filePath, 'rb') as fp:
        return fp.read()
        
        
print('begin upload...')


###非极速语音识别
content = client.asr(get_file_content(WAVE_OUTPUT_FILENAME), 'pcm', 16000, {
    'dev_pid': 1536,
})






'''
#RATE = "16000"
#FORMAT = "amr"
#CUID="wate_play"
DEV_PID="1536"

token = "24.5c457f0323663b4a5553a73425dae7ae.2592000.1564737615.282335-16644104"

with open(r'WAVE_OUTPUT_FILENAME', "rb") as f:
    speech = base64.b64encode(f.read()).decode('utf8')
size = os.path.getsize(r'WAVE_OUTPUT_FILENAME')
headers = { 'Content-Type' : 'application/json'} 
url = "https://vop.baidu.com/pro_api"
data={

        "format":FORMAT,
        "rate":RATE,
        "dev_pid":DEV_PID,
        "speech":speech,
        #"cuid":CUID,
        #"len":size,
        #"channel":1,
        "token":token,
    }

content = requests.post(url,json.dumps(data),headers)
#req = requests.post(url,json.dumps(data),headers)
#result = json.loads(req.text)


print(cotent["result"][0])
'''

if content:
    #print type(content)
    #print(content)
    result = content.get('result')
    #print type(result)
    resultStr = str(result)
    #print type(resultStr)
    resultUni = resultStr.decode("unicode-escape")
    #print type(resultUni)
    resultUtf = resultUni.encode('utf-8')
    print(type(resultUtf))
    print(resultUtf)
    
'''
{u'err_no': 0,
 u'corpus_no': u'6707772219289416824',
 u'err_msg': u'success.',
 u'result': [u'\u5317\u4eac\u79d1\u6280\u9986'],
 u'sn': u'724417436921561774923'}
'''