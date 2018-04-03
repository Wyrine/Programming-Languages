#!/usr/bin/env js

'use strict';
const myfs = require('fs');

class Pixel
{
	constructor(r = 0, g = 0, b = 0)
	{
		this.obj = {"r": r, "g": g, "b": b};
	}
	getRed() { return obj["r"]; }
	getGreen() { return obj["g"]; }
	getBlue() { return obj["b"]; }
	setRed(r)
	{
		if(typeof(r) != "number")
		{ throw new TypeError(); }
		this.obj["r"] = r;
	}
	setRed(g)
	{
		if(typeof(g) != "number")
		{ throw new TypeError(); }
		this.obj["g"] = g;
	}
	setRed(b)
	{
		if(typeof(b) != "number")
		{ throw new TypeError(); }
		this.obj["b"] = b;
	}
	invert(offVal)
	{
		this.obj["r"] = offVal - this.obj["r"];
		this.obj["g"] = offVal - this.obj["g"];
		this.obj["b"] = offVal - this.obj["b"];
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
	getPixel(x,y,pix)
	{
		if(x == undefined || y == undefined || pix == undefined ||
			x*y >= this.w * this.h){ throw new TypeError(); }
		return this.pArray[y*this.w + x];
	}
	clearPixels() { this.pArray.length = 0; }
	flipVertical() { this.pArray = this.pArray.reverse(); }
	flipHorizontal()
	{
		for(var i = 0; i < this.h; i++)
			for(var j = 0; j < Math.floor(this.w /2); i++)
			{
				var tmp = this.pArray[i * this.w + j];
				this.pArray[i*this.w + j] = this.pArray[i*this.w + this.w -1 -j];
				this.pArray[i*this.w + this.w -1 -j] = tmp;
			}
	}
}

function main()
{
	if(process.argv.length < 5)
	{
		console.error(`Usage: ${process.argv[0]} ${process.argv[1]} <input> <output> <flag>`);
		throw new RangeError();
	}
	
}
//call main
main()
