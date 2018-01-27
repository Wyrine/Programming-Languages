#include <stdio.h>
#include <stdlib.h>

struct Stack {
	int *data;
};

struct Node {
	int value;
	struct Node *left;
	struct Node *right;
};


/* Fibonacci */
long FibRecur(short n);
long FibTail(short n);
long FibHelper(short n, long rv1, long rv2);

/* Stack */
void Push(struct Stack *s, int value);
int Pop(struct Stack *s);

/* Tree */
struct Node *Insert(struct Node *root, int value);
struct Node *Search(struct Node *root, int search_value);
void PrintTree(struct Node *root);


int
main(int argc, char** argv)
{
	printf("tail: %ld | Recur: %ld\n", FibTail(2), FibRecur(8));
	struct Stack *s = calloc(1, sizeof(struct Stack));
	s->data =calloc(5, sizeof(int));
	s->data += 5;
	Push(s, 1);
	Push(s, 2);
	printf("First: %d, Second %d\n", Pop(s), Pop(s));
	
	return 0;
}
/*
long
FibRecur(short n)
{
	if( n <= 1 )
		return 1L;
	return FibRecur(n - 1) + FibRecur(n-2);
}
*/
/*
long
FibTail(short n)
{
	return FibHelper(n, 1L, 1L);
}

long
FibHelper(short n, long rv1, long rv2)
{
	if( n <= 0 ) return rv1;
	return FibHelper(n-1, rv2, rv1 + rv2);
}
*/
/*
void
Push(struct Stack *s, int value)
{
	(s->data)--;
	*(s->data) = value;
}
*/
/*
int
Pop(struct Stack *s)
{
	(s->data)++;
	return *(s->data - 1);
}	*/
