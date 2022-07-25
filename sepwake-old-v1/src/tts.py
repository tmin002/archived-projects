#!/usr/bin/python3
#-*- coding:utf-8 -*-
import os
import time
import datetime
import threading
import requests
import json

from src.base import *
from src.sounds import *

TTS_PARSE_BUFFER = ""
TTS_DOWNLOAD_CNT = 0
WORDS_TO_SAY = []


def tts_download():


	global TTS_DOWNLOAD_CNT
	global TTS_PARSE_BUFFER
	global TTS_USAGE_LIMIT_EXCEEDED
	global DEBUG


	if DEBUG[1]:
		return 0

	cnt=0
	for i in WORDS_TO_SAY:
		cnt+=1

		URL = 'https://ttsmp3.com/makemp3_new.php' 
		params = {	'msg': "'%s'"%i[0],
					'lang': i[1],
					'source': 'ttsmp3'}
		header = {'Content-Type': 'application/x-www-form-urlencoded'}

		res = requests.get(URL, headers=header)
		res = requests.post(URL, data=params)

		if "Usage Limit exceeded" in res.text:
			write("WARNING: 'ttsmp3.com' usage limit exceeded. TTS will be presented with svox-pico.","!")
			TTS_USAGE_LIMIT_EXCEEDED = True
			return 0

		#write(res.text)
		json_data = json.loads(res.text)
		shell("wget -qO %s/%s.mp3 %s"%(TMP_DIR,str(TTS_DOWNLOAD_CNT),json_data["URL"]))

		TTS_DOWNLOAD_CNT += 1

def tts_say():

	if TTS_USAGE_LIMIT_EXCEEDED==True:
		tts_say_svox()
		return 0

	for i in range(TTS_DOWNLOAD_CNT):
		#time.sleep(2)
		play("%s/%d.mp3"%(TMP_DIR,i))
		time.sleep(0.3)

def tts_clear_buffer():
	global WORDS_TO_SAY
	global TTS_PARSE_BUFFER
	global TTS_DOWNLOAD_CNT
	WORDS_TO_SAY = []
	TTS_PARSE_BUFFER = ""
	TTS_DOWNLOAD_CNT = 0
	shell('rm -rf %s; mkdir tmp'%TMP_DIR)

def tts_say_svox():
	for i in WORDS_TO_SAY:
		#shell("pico2wave -w %s/svox_voice.wav '%s' ; aplay -q %s/svox_voice.wav" % (TMP_DIR,i[0],TMP_DIR))
		shell('say -v Alex ' + i[0])
		time.sleep(1)




def tts_add_text(text):
	global TTS_PARSE_BUFFER
	TTS_PARSE_BUFFER += text + '\n\n'

def tts_end_text_chunk(voicename="Matthew", buffererase=True):
	global WORDS_TO_SAY
	global TTS_PARSE_BUFFER
	text = TTS_PARSE_BUFFER

	if buffererase:
		TTS_PARSE_BUFFER = ""

	WORDS_TO_SAY.append([text, voicename])
