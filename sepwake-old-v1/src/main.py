#!/usr/bin/python3
#-*- coding:utf-8 -*-
import os
import time
import datetime
import threading
import requests
import json
import subprocess

from src.base import *
from src.sounds import *
from src.tts import *

#shell('setterm -term linux -foreground black -background white ; clear')


def greeting_sequence():

	shell('clear')
	greeting_message()

	##################################
	##################################
	##################################

	datestr = ""
	dt=datetime.datetime.now()
	dayint = dt.weekday()
	monthint = dt.month

	if dayint==0:
		datestr += "Monday"
	if dayint==1:
		datestr += "Tuesday"
	if dayint==2:
		datestr += "Wednesday"
	if dayint==3:
		datestr += "Thursday"
	if dayint==4:
		datestr += "Friday"
	if dayint==5:
		datestr += "Saturday"
	if dayint==6:
		datestr += "Sunday"

	datestr += ", " + str(dt.day) + "th, "

	if monthint==1:
		datestr += "January"
	if monthint==2:
		datestr += "Febuary"
	if monthint==3:
		datestr += "March"
	if monthint==4:
		datestr += "April"
	if monthint==5:
		datestr += "May"
	if monthint==6:
		datestr += "June"
	if monthint==7:
		datestr += "July"
	if monthint==8:
		datestr += "August"
	if monthint==9:
		datestr += "Setember"
	if monthint==10:
		datestr += "October"
	if monthint==11:
		datestr += "November"
	if monthint==12:
		datestr += "December"

	datestr +=", " + str(dt.year)


	##################################
	##################################
	##################################

	shell('clear') #\033[47;30m  \033[47;04m
	write('')
	write('DATE= %s'%(str(dt.year))+'-'+str(dt.month)+'-'+str(dt.day))

	tts_add_text("Good morning.")
	tts_add_text("Today is %s"%datestr)
	tts_add_text("It is currently %s, and you have 5 minutes until the morning broadcast."%( str(dt.hour)+"\n"+str(dt.minute)))
	tts_end_text_chunk()
	tts_download()
	tts_say()

	min_wait_sec = 10
	for i in range(min_wait_sec):
		write('Broadcast %d:%d left\r'%( (min_wait_sec - i) // 60  ,  (min_wait_sec - i) %60  ),title='-',flush=True)
		time.sleep(1)

	##################################
	##################################
	##################################
	"""
	from bs4 import BeautifulSoup
	from pprint import pprint
	import requests

	html = requests.get('https://search.naver.com/search.naver?query=날씨')
	#pprint(html.text)

	soup = BeautifulSoup(html.text, 'html.parser')

	data1 = soup.find('div', {'class': 'weather_box'})
	find_currenttemp = data1.find('span',{'class': 'todaytemp'}).text
	find_min= data1.find('span',{'class': 'min'}).text
	find_max = data1.find('span',{'class': 'max'}).text
	find_txt = data1.find('p',{'class': 'cast_txt'}).text
	"""

	tts_clear_buffer()
	tts_add_text("Good morning. It is %d, %d in the morning."%(datetime.datetime.now().hour, datetime.datetime.now().minute))
	#tts_add_text("Current temperture is %d degrees celcius."%int(find_currenttemp.replace("˚","")))
	#tts_add_text("Today's maximum will be %d degrees celcius, and minimum %d degrees celcius."%(int(find_max.replace("˚","")),int(find_min.replace("˚",""))))
	tts_add_text("It is expected to be, ")
	tts_end_text_chunk()
	#tts_add_text(find_txt.replace("˚","도 "))
	#tts_end_text_chunk("Seoyeon")
	time.sleep(3)
	tts_add_text("Now initiating the wakeup action provoke procedure.")
	tts_add_text("Starting in  \n\n\n 5 \n\n\n 4 \n\n\n 3 \n\n\n 2 \n\n\n 1 \n\n\n")

	tts_end_text_chunk()
	tts_download()
	tts_say()
	play('alarmsounds/beep-15.mp3')

	return 0


def greeting_message():
	write('S.E.P. (Self Enhancement Project) Manager')
	write('written by ssh9930, wishing for successfully reaching the goal.')
	write("This program is based on WOL feature. only intended for myself.\n")
	write('Alarm ring time: %d:%d'%(WAKEUP_TIME_HOUR, WAKEUP_TIME_MINUTE))


def main(msgonly=False):

	global WAIT_SUSPEND_SEC

	greeting_message()

	#write("Working virtual terminal: #%d"%VT)
    # 
	#if not 'tty%d'%VT in subprocess.Popen("tty", shell=True, stdout=subprocess.PIPE).stdout.read().decode() and not DEBUG[2]:
	#	write('Current virtual terminal != #%d, terminaing.'%(VT),'!')
	#	exit()

	if msgonly:
		return 0
	#elif ASK_SUDO:
	#	write('SEP Manager requires sudo authentication.','!')
	#	shell("sudo echo -e '\033[32m[-]\033[03m	sudo authentication successfully done.'")
	#	print('')


	while(nmin()!=dmin() and DEBUG[0]==False):
		write('Not alarm ring time. waiting..',flush=True)
		time.sleep(1)

	greeting_sequence()
	shell('./sep-manager.py')




	#write('SEP Manager requires ROOT permission to seamlessly change between virtual terminals.','!')
	#while(nmin()!=dmin() and DEBUG[0]==False):
	#	write("Not alarm ring time, suspending..")
	#	for i in range(WAIT_SUSPEND_SEC):
	#		write('Suspending system in %d seconds..\r'%(WAIT_SUSPEND_SEC-i),title='!',flush=True)
	#		time.sleep(1)
	#	shell('systemctl suspend')
	#	time.sleep(5)


