#!/usr/bin/env python3

from sys import argv, exit

class Pixel:
	def __init__(self, r=0, g=0, b=0):
		self.__mDict = {"r": r, "g": g, "b":b}

	def getRed(self):
		return self.__mDict["r"]

	def getGreen(self):
		return self.__mDict["g"]

	def getBlue(self):
		return self.__mDict["b"]

	def invert(self, offVal):
		self.__mDict["r"] = offVal - self.__mDict["r"]
		self.__mDict["g"] = offVal - self.__mDict["g"]
		self.__mDict["b"] = offVal - self.__mDict["b"]

	def setRed(self, r):
		if r is not int:
			raise TypeError
		self.__mDict["r"] = r

	def setBlue(self, b):
		if b is not int:
			raise TypeError
		self.__mDict["b"] = b

	def setGreen(self, g):
		if g is not int:
			raise TypeError
		self.__mDict["g"] = g

class PPM:
	def __init__(self, w, h, intensity):
		self.__mPix = []
		self.__curRow = 0 
		self.__curCol = -1
		tmp = [None for i in range(w)]

		for i in range(h):
			self.__mPix.append(tmp[:])

		self.__maxIntensity = intensity
		self.__w = w
		self.__h = h

	def invert(self):
		for row in self.__mPix:
			for pix in row:
				if pix == None:
					raise IndexError
				pix.invert(self.__maxIntensity)

	def flipHorizontal(self):
		pass
	
	def flipVertical(self):
		pass
	
	def addPixel(self, pix):
		self.__curCol += 1
		if self.__curCol == self.__w:
			self.__curCol = 0
			self.__curRow += 1
		if self.__curRow == self.__h:
			raise IndexError
		self.__mPix[self.__curRow][self.__curCol] = pix
		print(pix.getRed(), pix.getGreen(), pix.getBlue())

	def clearPixels(self):
		self.__mPix.clear()	
		self.__curRow = 0
		self.__curCol = -1
		tmp = [None for i in range(w)]

		for i in range(h):
			self.__mPix.append(x[:])

	def getPixel(self, x, y):
		if x >= self.__w or y >= self.__h or self.__mPix[x][y] == None:
			raise KeyError
		return self.__mPix[x][y]

	def setPixel(self, x, y, pix):
		if x >= self.__w or y >= self.__h:
			raise KeyError
		self.__mPix[x][y] = pix

	def getHeight(self):
		return self.__h
	
	def getWidth(self):
		return self.__w

	def getMaxIntensity(self):
		return self.__maxIntensity

def buildPPM(fName):
	ppm = None
	with open(fName) as fin:
		if "P3" not in fin.readline():
			raise IOError
		try:
			#read line that has width and height
			t = fin.readline().split()
			w, h = int(t[0]), int(t[1])
			#read line that has max intensity
			t = fin.readline().split()
			maxInt = int(t[0])
			#make a new ppm instance
			ppm = PPM(w,h,maxInt)	

		except: raise IOError
	
		#for all lines
		for line in fin:
			#make a list based on white space separation and remove new lines
			tmp = line.replace("\n", "").split()
			#Iterate through multiples of three for rgb and get those values
			for i in range(0, len(tmp), 3):
				r, g, b = int(tmp[i]), int(tmp[i+1]), int(tmp[i+2])
				#otherwise create a new pixel instance and add to ppm
				pix = Pixel(r,g,b)
				ppm.addPixel(pix)	
	return ppm

def normalWrite(ofName, ppm):
	with open(ofName, "w") as fout:
		r, c, mI = ppm.getHeight(), ppm.getWidth(), ppm.getMaxIntensity()
		fout.write("P3\n" + str(c) + " " + str(r) + "\n" + str(mI))	
		for i in range(r):#TODO: Change this
			for j in range(c):#TODO: Change this
				pix = ppm.getPixel(i,j)
				fout.write("\n" + str(pix.getRed()) + " " + str(pix.getGreen()) + " " + str(pix.getBlue()))
	

def writeFile(ofName, flag, ppm):
	if flag == "V":
		ppm.invert()
	elif flag == "FH":
		ppm.flipHorizontal()
	elif flag == "FV":
		ppm.flipVertical()
	elif flag != "N":
		raise ValueError
	normalWrite(ofName, ppm)

def main():
	if len(argv) < 4:
		print("Usage: ./lab6.py <input_file> <output_file> <mode>")
		return 1

	ppm = buildPPM(argv[1])
	writeFile(argv[2], argv[3], ppm)
	return 0

if __name__ == "__main__":
	exit(main())
