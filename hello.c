#include <stdio.h>
void main()
{
  printf("hello world\n%d",is_odd(10));
}
int is_odd(int n)
{
 if (n==0)
     return 1;
 else 
    return is_even(n-2);
}
int is_even(int n)
{
  if(n==1)
    return 0;
  else 
    return is_odd(n-2);
}
