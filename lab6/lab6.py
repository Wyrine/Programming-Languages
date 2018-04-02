#!/usr/bin/env python3

from sys import argv, exit

class Pixel:
	def __init__(self):
		self.__mDict = {"r": 0, "g": 0, "b":0}

	def getRed(self):
		return self.__mDict["r"]

	def getGreen(self):
		return self.__mDict["g"]

	def getBlue(self):
		return self.__mDict["b"]

	def setRed(self, r):
		self.__mDict["r"] = r

	def setBlue(self, b):
		self.__mDict["b"] = b

	def setGreen(self, g):
		self.__mDict["g"] = g

class PPM:
	def __init__(self, w, h, intensity):
		#this needs to be 2D
		self.__mPix = []
		self.__maxIntensity = intensity
		self.__w = w
		self.__h = h

	def invert(self):
		pass

	def flipHorizontal(self):
		pass
	
	def flipVertical(self):
		pass
	
	def addPixel(self, pix):
		if len(self.__mPix[-1]) < self.__w:
			self.__mPix[-1].append(pix)
		else:
			self.__mPix.append([pix])
	
	def clearPixels(self):
		self.__mPix.clear()
	
	def getPixel(self, x, y):
		try:
			return self.__mPix[x][y]
		except:
			raise KeyError

	def setPixel(self, x, y, pix):
		try:
			self.__mPix[x][y] = pix
		except:
			raise KeyError

	def getHeight(self):
		return self.__h
	
	def getWidth(self):
		return self.__w

	def getMaxIntensity(self):
		return self.__maxIntensity

def buildPPM(fName):
	ppm = 0
	with open(fName) as fin:
		if "P3" not in fin.readline():
			return 2
		try:
			t = fin.readline().split()
			w, h = int(t[0]), int(t[1])
			t = fin.readline().split()
			maxInt = int(t[0])
			ppm = PPM(w,h,maxInt)	
			
		except IndexError:
			raise IOError

def main():
	buildPPM(argv[1])
	if len(argv) < 4:
		print("Usage: ./main.py <input_file> <output_file> <mode>")
		return 1
	
	return 0

if __name__ == "__main__":
	exit(main())
