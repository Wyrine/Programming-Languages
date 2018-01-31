
class mystring
{
	char *mString;
	int mStringLength;

public:
	//Destructor. You must free whatever was allocated in mString and reset
	//the mString pointer and mStringLength to 0.
	~mystring();

	//Default constructor sets mString to an empty string
	//and mStringLength to 0. Do NOT let mString be a NULL pointer, ever!
	mystring();

	//Constructor that takes a C-style string pointer. You must allocate
	//memory for mString and COPY src into it. Then determine the length
	//and store that into mStringLength
	mystring(const char *src);

	//Constructor that takes a mystring. You must copy mString and mStringLength.
	//DO NOT just copy the pointer. You must allocate a new pointer and
	//copy the string.
	myString(const mystring &rhs);

	//Assignment of C-style string. This must function just like
	//mystring(const char *src) except that in this function, you must
	//free the old mString pointer. This returns a reference to the class.
	mystring &operator=(const char &src);

	//Assignment of an rvalue mystring. All you have to do is copy the pointer
	//and length. You must not reallocate the pointer since is an rvalue
	//which is what the && denotes.
	mystring &operator=(const mystring &&rhs);

	//Simply return mStringLength
	int length() const;

	//Find the location of the needle. Return -1 if the needle
	//was not found, or the index if it was.
	int find(const mystring &needle) const;

	//Same as find above, except this is given the needle as a C-style string.
	int find(const char *needle) const;

	//Simply return mString pointer.
	const char *c_str() const;

	//This allows us to cout << mystring. This is a friend, so this is
	//static with no this pointer. The ostream class knows how to output
	//a c-style string, so that is what needs to be written to s. You
	//will need to return the reference of ostream &s.
	friend ostream &operator<<(ostream &s, const mystring &rhs);
};

