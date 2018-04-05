#!/usr/bin/env js

/* Kirolos Shahat
 * CS 365 -- Lab 5
 * Due Date: April 5th
 */

//strict mode
'use strict';
const fs = require('fs');

class Pixel
{
	constructor(_r, _g, _b)
	{
		console.log
		this.obj = {r: _r, g: _g, b: _b};
	}
	//getters
	getRed() { return this.obj.r; }
	getGreen() { return this.obj.g; }
	getBlue() { return this.obj.b; }
	get Red() { return this.obj.r; }
	get Green() { return this.obj.g; }
	get Blue() { return this.obj.b; }
	//setters
	setRed(r)
	{
		if(typeof(r) != 'number')
		{ throw new TypeError(); }
		this.obj["r"] = r;
	}
	setGreen(g)
	{
		if(typeof(g) != 'number')
		{ throw new TypeError(); }
		this.obj["g"] = g;
	}
	setBlue(b)
	{
		if(typeof(b) != 'number')
		{ throw new TypeError(); }
		this.obj["b"] = b;
	}
	set Red(r){ this.setRed(r); }
	set Green(g){ this.setGreen(g); }
	set Blue(b){ this.setBlue(b); }
	invert(offVal)
	{
		this.obj['r'] = offVal - this.obj['r'];
		this.obj['g'] = offVal - this.obj['g'];
		this.obj['b'] = offVal - this.obj['b'];
	}
}

class PPM
{
	constructor(w, h, intensity)
	{
		this.pArray = [];
		this.w = w;
		this.h = h;
		this.maxIntensity = intensity;
	}
	getHeight() { return this.h; }
	getWidth() { return this.w; }
	getMaxIntensity() { return this.maxIntensity; }
	get Height() { return this.h; }
	get Width() { return this.w; }
	get MaxIntensity() { return this.maxIntensity; }
	invert()
	{
		//iterate through all of the pixels and call each invert
		for(var i in this.pArray)
			 this.pArray[i].invert(this.maxIntensity);
	}
	addPixel(pix)
	{
		//throw an exception if pix is undefined or the dimensions get too high
		if(pix == undefined || this.pArray.length >= this.w * this.h)
			throw new TypeError();
		this.pArray.push(pix);
	}
	setPixel(x,y,pix)
	{
		//throw an exception if x,y, or pix are undefined or the dimensions are too high
		if(x == undefined || y == undefined || pix == undefined ||
				x*y >= this.w * this.h){ throw new TypeError(); }
		this.pArray[y*this.w + x] = pix;
	}
	getPixel(x,y)
	{
		//throw an exception if x or y are undefined or the dimensions are too high
		if(x == undefined || y == undefined || x*y >= this.w * this.h)
		{ throw new TypeError(); }
		return this.pArray[y*this.w + x];
	}
	clearPixels() { this.pArray.length = 0; }
	flipVertical() { 
		//swap order of rows
		for(var i = 0; i< Math.floor(this.h * 0.5); i++)
		{
			//row to swap with
			var i2 = this.h - i - 1;
			for(var j = 0; j < this.w; j++)
			{
				//perform swaps
				var j1 = i*this.w + j;
				var j2 = i2*this.w + j;
				var tmp = this.pArray[j1];
				this.pArray[j1] = this.pArray[j2];
				this.pArray[j2] = tmp;
			}
		}
	}
	flipHorizontal()
	{
		//iterate through the rows
		for(var i = 0; i < this.h; i++)
			//and through half of the columns with integer division
			for(var j = 0; j < Math.floor(this.w * 0.5); j++)
			{
				//swap a pixel in this row so that it reverses the row
				var i1 = i*this.w + j;
				var i2 = i*this.w + this.w -j -1;
				var tmp = this.pArray[i1];
				this.pArray[i1] = this.pArray[i2];
				this.pArray[i2] = tmp;
			}
	}
}

function readPPM()
{
	var d = '';
	const fin = fs.createReadStream(process.argv[2], {flags: 'r', encoding: 'utf8'});
	//do the reading
	fin.on('data', (chunk) => {
		d += chunk;
	});
	//once the reading is complete and the file is being closed.
	fin.on('close', () => { 
		//split the data on new line
		d = d.split('\n');
		if(d[0] != 'P3') throw 'Wrong Header';
		d.shift();
		//get the width and height
		var dims = d[0].split(' ');
		d.shift();
		//get the max intensity
		var mI = parseInt(d[0]);
		d.shift();
		//removing one newline at the end
		d.pop();
		//queue the rest into the event queue
		setImmediate( () => {
			//build the ppm
			var ppm = buildPPM(new PPM(parseInt(dims[0]), parseInt(dims[1]), mI), d);
			//perform the needed action and write
			alterAndWritePPM(ppm);
		});
	});
}

function buildPPM(ppm, data)
{
	//join the data on whitespace and then split on
	//whitespace to get it all in single color per element 
	data = data.join(' ').split(' ');
	//remove any erroneous white space from the array
	data = data.filter(data => data.length > 0);
	//go through the array three elements at a time
	try{
		for(var i = 0; i < data.length; i += 3)
		{
			var r = parseInt(data[i]);
			var g = parseInt(data[i+1]);
			var b = parseInt(data[i+2]);
			ppm.addPixel(new Pixel(r,g,b));
		}
	}
	catch(err) { throw err; }
	return ppm;
}

function alterAndWritePPM(ppm)
{
	//perform the needed operation on the ppm
	switch(process.argv[4])
	{
		case 'V':
			ppm.invert();
			break;
		case 'FH':
			ppm.flipHorizontal();
			break;
		case 'FV':
			ppm.flipVertical();
			break;
		case 'N':
			break;
		default:
			throw `Unkown argument ${process.argv[4]}`;
	}
	//perform the writePPM function async
	setImmediate( () =>{
		writePPM(ppm);
	});
}

function writePPM(ppm)
{
	var fout = fs.createWriteStream(process.argv[3], {flags: 'w', encoding: 'utf8'});
	var w = ppm.Width;
	var h = ppm.Height;
	var mI = ppm.MaxIntensity;
	
	//print the header to the file
	fout.write(`P3\n${w} ${h}\n${mI}\n`);
	//write the contents of each pixel
	for(var i = 0; i< h; i++)
		for(var j = 0; j < w; j++)
		{
			var pix = ppm.getPixel(j, i);
			fout.write(`${pix.Red} ${pix.Green} ${pix.Blue}\n`);
		}
	fout.end();
}

function main()
{
	if(process.argv.length < 5)
	{
		console.error(`Usage: ${process.argv[0]} ${process.argv[1]} <input> <output> <flag>`);
		throw new RangeError();
	}
	readPPM(process.argv[2]);
}
main()
