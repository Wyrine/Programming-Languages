using System;

class varags
{
    static void Main()
    {
        printf("Hello world %s %d %ld", "Hello", 12, 33L);
    }

    static void printf(string fmt, params object[] args)
    {
        int arg = 0;
        for(int i = 0; i < fmt.Length;i++)
        {
            if(fmt[i] != '%')
                Console.Write(fmt[i]);
            else
            {
                if((++i+ < fmt.Length){
                    switch (fmt[i])
                    {
                        default:
                            Console.Write(fmt[i]);
                            break;
                        case 's':
                            Console.Write(args[arg++] as string);
                            break;
                        case 'd':
                            Console.Write(args[arg++] as int?);
                            break;
                        case 'l':
                            Console.Write(args[arg++] as long?);
                            i++;
                            break;
                    }
            }
        }
    }
}
