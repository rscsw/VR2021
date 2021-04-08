using System;
using System.Text;
using static System.Console;

namespace CSW
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0) //이름을 입력했을 때만 테두리가 출력되도록 설정함
            {
                WriteLine(); //윗줄이랑 붙어있으면 보기 안 예쁘니까 한 칸 띄워줌
                for (int i = 0; i < args.Length; i++)
                {
                    Write("*"); //배열의 크기만큼 *을 출력함
                    for (int j = 0; j < args[i].Length; j++)
                        Write("*"); //각 배열의 글자수만큼 *을 출력함
                }  
                Write("*\n*"); //모자른 한 칸 채워주고 줄바꿈하고 이름 옆에 * 붙여줌
                if (args.Length == 1)
                {
                    Write(args[0]); //배열을 하나만 입력했을 경우 0번째 방에 저장된 배열만 출력되도록 설정함
                }
                else if (args.Length >= 2) //배열을 두 개 이상 입력했을 경우
                {
                    for (int i = 0; i < args.Length - 1; i++)
                        Write(args[i] + " "); //배열의 끝에서 두번째까지만 출력함, 옆에 한 칸 띄워줌
                    Write(args[args.Length - 1]); //배열의 마지막을 출력함, 옆에 공백이 있으면 테두리가 안 예쁘니까
                }
                WriteLine("*"); //이름 옆에 *
                for (int i = 0; i < args.Length; i++)
                {
                    Write("*");
                    for (int j = 0; j < args[i].Length; j++)
                        Write("*");
                } //16~21번째 줄과 동일하게 * 출력함
                WriteLine("*"); //모자른 한 칸 채워줌
            }

            Write("\n숫자를 입력하세요 : "); //숫자 입력하도록 지시
            try
            {
                int num = Convert.ToInt32(ReadLine()); //ReadLine()을 통해 입력한 숫자를 num에 저장함
                if (num >= 0) //num이 음수가 아닐 경우
                {
                    WriteLine("\n1. 입력받은 숫자 : " + num); //입력받은 num값을 출력함
                    Calculate(num); //Calculate 함수 실행
                }
                else
                    WriteLine("오류! 음수를 입력하였습니다."); //num이 음수일 경우 오류 발생 메세지 출력
            }
            catch (FormatException)
            {
                WriteLine("오류! 문자를 입력하였습니다."); //문자를 입력할 경우 오류 발생 메세지 출력
            }
            catch (OverflowException)
            {
                WriteLine("오류! int 범위를 넘어갑니다."); //int 범위를 넘어가는 숫자를 입력했거나
            }                                              //뒤집기, 계산 과정에서 int 범위를 넘어갈 경우
        }                                                  //오류 발생 메세지 출력

        static void Calculate(int num)
        {
            string arr = Convert.ToString(num); //num을 int에서 string으로 변환해줌
            char[] numrev = arr.ToCharArray(); //string을 char의 배열로 변환해줌
            Array.Reverse(numrev); //배열을 역순으로 뒤집어줌
            int rnum = Convert.ToInt32(new string(numrev)); //뒤집힌 char의 배열을 새로운 string으로 저정한 뒤 rnum에 저장해줌
            WriteLine("2. 숫자 뒤집기 : " + rnum); //rnum을 출력해줌
            int a = num + 1111; //num 더하기 1111을 a에 저장함
            int b = rnum + 1111; //rnum 더하기 1111을 b에 저장함
            WriteLine("3. 입력받은 숫자에 1111 더하기 : " + a); //a와 b를
            WriteLine("4. 뒤집은 숫자에 1111 더하기 : " + b);   //출력함
            Write("5. 뒤집은 숫자와 입력받은 숫자중에 더 큰 숫자 : ");
            if (a > b)
                WriteLine(a); //a가 더 클 경우 a를 출력함
            else if (b > a)
                WriteLine(b); //b가 더 클 겨우 b를 출력함
            else if (a == b)
                WriteLine("두 숫자가 같습니다."); //a와 b가 같을 경우 두 숫자가 같다는 메세지를 출력함
        }
    }
}
