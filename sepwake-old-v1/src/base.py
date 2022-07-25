#!/usr/bin/python3
#-*- coding:utf-8 -*-
import os
import time
import datetime
import threading
import requests
import json

WAKEUP_TIME_HOUR = 23 
WAKEUP_TIME_MINUTE = 15

NOISE_THREAD = threading.Thread()
NOISE_THREAD_STOP = False

ASK_SUDO = True

DEBUG = [0,0,0] #waitforalarm, donwloaddebug, vtpass


PWD = os.getcwd()

SOUNDS_DIR = "%s/sounds"%PWD
INFOS_DIR = "%s/infos"%PWD
TMP_DIR = "%s/tmp"%PWD

TTS_USAGE_LIMIT_EXCEEDED = False

def write(text,title="-",flush=False):
	if(title=="!"):
		#print("\033[41;30m", end="")
		print("\033[31m", end="")
	else:
		#print("\033[42;30m", end="")
		print("\033[32m", end="")

	if flush:
		#print("[%s]\033[47;30m  %s" % (title,text), end='\r', flush=True)
		print("[%s]\033[0m  %s" % (title,text), end='\r', flush=True)
	else:
		#print("[%s]\033[47;30m  %s" % (title,text))
		print("[%s]\033[0m  %s" % (title,text))

def shell(text,silent=False):
	if silent:
		os.system(text+" >/dev/null 2>&1")
	else:
		os.system(text)

def nmin():
	return datetime.datetime.today().hour*60  + datetime.datetime.today().minute

def dmin():
	return WAKEUP_TIME_HOUR* 60 + WAKEUP_TIME_MINUTE
