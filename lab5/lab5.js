#!/usr/bin/env js

'use strict';
const fs = require('fs');

class Pixel
{
	constructor(_r = 0, _g = 0, _b = 0)
	{
		this.obj = {r: _r, g: _g, b: _b};
	}
	getRed() { return this.r; }
	getGreen() { return this.g; }
	getBlue() { return this.b; }
	setRed(r)
	{
		if(typeof(r) != 'number')
		{ throw new TypeError(); }
		this.obj["r"] = r;
	}
	setRed(g)
	{
		if(typeof(g) != 'number')
		{ throw new TypeError(); }
		this.obj["g"] = g;
	}
	setRed(b)
	{
		if(typeof(b) != 'number')
		{ throw new TypeError(); }
		this.obj["b"] = b;
	}
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
	invert()
	{
		for(var i in this.pArray)
			this.pArray[i].invert(this.maxIntensity);
	}
	addPixel(pix)
	{
		if(pix == undefined || this.pArray.length >= this.w * this.h)
			throw new TypeError();
		this.pArray.push(pix);
	}
	setPixel(x,y,pix)
	{
		if(x == undefined || y == undefined || pix == undefined ||
				x*y >= this.w * this.h){ throw new TypeError(); }
		this.pArray[y*this.w + x] = pix;
	}
	getPixel(x,y)
	{
		if(x == undefined || y == undefined || x*y >= this.w * this.h)
		{ throw new TypeError(); }
		return this.pArray[y*this.w + x];
	}
	clearPixels() { this.pArray.length = 0; }
	flipVertical() { setImmediate(()=>{ this.pArray = this.pArray.reverse(); }); }
	flipHorizontal()
	{
		for(var i = 0; i < this.h; i++)
			for(var j = 0; j < Math.floor(this.w /2); i++)
			{
				setImmediate(() => {
					var i1 = i*this.w + j;
					var i2 = i*this.w + this.w -j -1;
					var tmp = this.pArray[i1];
					this.pArray[i1] = this.pArray[i2];
					this.pArray[i2] = tmp;
				});
			}
	}
}

function readPPM()
{
	var d = '';
	const fin = fs.createReadStream(process.argv[2], {flags: 'r', encoding: 'utf8'});
	fin.on('data', (chunk) => {
		d += chunk;
	});
	fin.on('close', () => { 
		d = d.split('\n');
		if(d[0] != 'P3') throw 'Wrong Header';
		d.shift();
		var dims = d[0].split(' ');
		d.shift();
		var mI = parseInt(d[0]);
		d.shift();
		//removing one newline at the end
		d.pop();
		setImmediate(() => {
			var ppm = buildPPM(new PPM(parseInt(dims[0]), parseInt(dims[1]), mI), d);
			d.length = 0;
			alterAndWritePPM(ppm);

		});
	});
}

function buildPPM(ppm, data)
{
	data = data.join(' ').split(' ');
	for(var i = 0; i < data.length; i+= 3)
	{
//		setImmediate(() =>{
			var r = parseInt(data[i]);
			var g = parseInt(data[i+1]);
			var b = parseInt(data[i+2]);
			ppm.addPixel(new Pixel(r,g,b));
//		});
	}
	return ppm;
}

function alterAndWritePPM(ppm)
{
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
	writePPM(ppm);
}

function writePPM(ppm)
{
	var fout = fs.createWriteStream(process.argv[3], {flags: 'w', encoding: 'utf8'});
	var w = ppm.getWidth();
	var h = ppm.getHeight();
	var mI = ppm.getMaxIntensity();
	
	fout.write(`P3\n${w} ${h}\n${mI}`);
	for(var i = 0; i< h; i++)
		for(var j = 0; j < w; j++)
		{
//			setImmediate(() => {
			var pix = ppm.getPixel(j, i);
			fout.write(`\n${pix.getRed()} ${pix.getGreen()} ${pix.getBlue()}`);
//			});
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
