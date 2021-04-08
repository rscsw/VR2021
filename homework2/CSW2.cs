using System;
using static System.Console;

namespace RomanNumerals
{
    class Program
    {
        static void Main()
        {
            while (true) //반복문
            {
                int num = 0; //변환 후 출력할 아라비아 숫자를 저장하는 값 num 생성 및 초기화
                bool romErr = false; //로마 숫자 입력 규칙 오류를 감지하는 bool값 romErr 생성
                bool chrErr = false; //지정된 문자 외에 다른 문자를 입력한 경우를 감지하는 bool값 chrErr 생성

                Write("숫자를 입력해주세요 : "); //숫자 입력 요구 메세지 출력
                string roma = ReadLine(); //숫자 입력 시 문자열 roma에 저장
                char[] rom = roma.ToCharArray(); //roma를 문자의 배열 rom으로 변환

                if (1 > roma.Length)
                    WriteLine("최소 1자 이상 입력해야합니다.\n"); //roma의 길이가 1 미만일 경우 경고 메세지 출력
                else if (roma.Length > 15)
                    WriteLine("입력 가능한 문자열의 길이를 초과하였습니다. 15자 이내로 입력해주세요.\n"); //roma의 길이가 15 초과일 경우 경고 메세지 출력
                else
                {
                    if (rom.Length > 2) //로마자가 3글자 이상일 때 실행
                    {
                        for (int i = 0; i < rom.Length - 2; i++) //끝에서 세번째 글자까지만 실행되도록 함
                        {                                        //왜냐하면 뒤의 뒤 글자까지 검사하도록 할 예정이기 때문
                            switch (rom[i])
                            {
                                case 'M':
                                    num += 1000;
                                    break;
                                case 'D':
                                    if (rom[i + 1] == 'M' || rom[i + 1] == 'D') //DM, DD일 경우 오류
                                        romErr = true;
                                    if (rom[i + 1] == 'C')
                                        if (rom[i + 2] == 'M' || rom[i + 2] == 'D') //CDM, DCD일 경우 오류
                                            romErr = true;
                                    num += 500; //오류 여부와 상관없이 일단 수를 더해줌
                                    break;      //어차피 오류를 인식할 경우 수를 출력하지 않기 때문
                                case 'C':
                                    if (rom[i + 1] == 'M')
                                        if (rom[i + 2] == 'M' || rom[i + 2] == 'D' || rom[i + 2] == 'C') //이하 동문
                                            romErr = true;
                                    if (rom[i + 1] == 'D')
                                        if (rom[i + 2] == 'M' || rom[i + 2] == 'C')
                                            romErr = true;
                                    if (rom[i + 1] == 'C')
                                        if (rom[i + 2] == 'M' || rom[i + 2] == 'D')
                                            romErr = true;
                                    num += 100;
                                    break;
                                case 'L':
                                    if (rom[i + 1] == 'M' || rom[i + 1] == 'D' || rom[i + 1] == 'C' || rom[i + 1] == 'L')
                                        romErr = true;
                                    if (rom[i + 1] == 'X')
                                        if (rom[i + 1] == 'C' || rom[i + 1] == 'L')
                                            romErr = true;
                                    num += 50;
                                    break;
                                case 'X':
                                    if (rom[i + 1] == 'M' || rom[i + 1] == 'D')
                                        romErr = true;
                                    if (rom[i + 1] == 'C')
                                        if (rom[i + 2] == 'M' || rom[i + 2] == 'C' || rom[i + 2] == 'D' || rom[i + 2] == 'L' || rom[i + 2] == 'X')
                                            romErr = true;
                                    if (rom[i + 1] == 'L')
                                        if (rom[i + 2] == 'X')
                                            romErr = true;
                                    if (rom[i + 1] == 'X')
                                        if (rom[i + 1] == 'C' || rom[i + 1] == 'L')
                                            romErr = true;
                                    num += 10;
                                    break;
                                case 'V':
                                    if (rom[i + 1] == 'M' || rom[i + 1] == 'D' || rom[i + 1] == 'C' || rom[i + 1] == 'L' || rom[i + 1] == 'X' || rom[i + 1] == 'V')
                                        romErr = true;
                                    if (rom[i + 1] == 'I')
                                        if (rom[i + 2] == 'X' || rom[i + 1] == 'V')
                                            romErr = true;
                                    num += 5;
                                    break;
                                case 'I':
                                    if (rom[i + 1] == 'M' || rom[i + 1] == 'D' || rom[i + 1] == 'C' || rom[i + 1] == 'L')
                                        romErr = true;
                                    if (rom[i + 1] == 'X')
                                        if (rom[i + 2] == 'C' || rom[i + 2] == 'L' || rom[i + 2] == 'X' || rom[i + 2] == 'V' || rom[i + 2] == 'I')
                                            romErr = true;
                                    if (rom[i + 1] == 'V')
                                        if (rom[i + 1] == 'I')
                                            romErr = true;
                                    if (rom[i + 1] == 'I')
                                        if (rom[i + 2] == 'X' || rom[i + 2] == 'V')
                                            romErr = true;
                                    num += 1;
                                    break;
                                default:
                                    chrErr = true; //로마 숫자가 아닌 다른 문자 입력 시 오류
                                    break;
                            }
                        }
                    }

                    if (rom.Length > 1) //두 글자 이상일 때 실행
                    {
                        switch (rom[rom.Length - 2]) //바로 뒤의 글자까지만 검사함
                        {
                            case 'M':
                                num += 1000;
                                break;
                            case 'D':
                                if (rom[rom.Length - 1] == 'M' || rom[rom.Length - 1] == 'D')
                                    romErr = true;
                                num += 500;
                                break;
                            case 'C':
                                num += 100;
                                break;
                            case 'L':
                                if (rom[rom.Length - 1] == 'M' || rom[rom.Length - 1] == 'D' || rom[rom.Length - 1] == 'C' || rom[rom.Length - 1] == 'L')
                                    romErr = true;
                                num += 50;
                                break;
                            case 'X':
                                if (rom[rom.Length - 1] == 'M' || rom[rom.Length - 1] == 'D')
                                    romErr = true;
                                num += 10;
                                break;
                            case 'V':
                                if (rom[rom.Length - 1] == 'M' || rom[rom.Length - 1] == 'D' || rom[rom.Length - 1] == 'C' || rom[rom.Length - 1] == 'L' || rom[rom.Length - 1] == 'X' || rom[rom.Length - 1] == 'V')
                                    romErr = true;
                                num += 5;
                                break;
                            case 'I':
                                if (rom[rom.Length - 1] == 'M' || rom[rom.Length - 1] == 'D' || rom[rom.Length - 1] == 'C' || rom[rom.Length - 1] == 'L')
                                    romErr = true;
                                num += 1;
                                break;
                            default:
                                chrErr = true;
                                break;
                        }
                    }

                    switch (rom[rom.Length - 1]) //로마자의 길이와 상관없이 마지막 글자를 검사함
                    {                            //최소 1자 이상 입력해야하기 때문
                        case 'M':
                            num += 1000;
                            break;
                        case 'D':
                            num += 500;
                            break;
                        case 'C':
                            num += 100;
                            break;
                        case 'L':
                            num += 50;
                            break;
                        case 'X':
                            num += 10;
                            break;
                        case 'V':
                            num += 5;
                            break;
                        case 'I':
                            num += 1;
                            break;
                        default:
                            chrErr = true;
                            break;
                    }

                    if (roma.Contains("CM") || roma.Contains("CD")) //roma에 CM이나 CD가 있을 경우 num에서 200 감소
                        num -= 200;                                 //CM과 CM는 함께 존재할 수 없기 때문에 || 연산자를 사용함
                    if (roma.Contains("XC") || roma.Contains("XL")) //위와 같음
                        num -= 20;
                    if (roma.Contains("IX") || roma.Contains("IV"))
                        num -= 2;

                    if (roma.Contains("IIII") || roma.Contains("MMMM") || roma.Contains("XXXX") || roma.Contains("CCCC")) //연속 네 번 이상 사용할 수 없는 문자 포함 시 오류
                        romErr = true;

                    if (chrErr) //chrErr의 값이 참일 경우 경고 메세지 출력
                        WriteLine("I, V, X, L, C, D, M만 입력할 수 있습니다.\n");
                    else if (romErr) //romErr의 값이 참일 경우 경고 메세지 출력
                        WriteLine("로마 숫자 규칙을 준수해주세요.\n");
                    else if (0 > num || num > 3999) //num이 0보다 작거나 3999보다 클 경우 경고 메세지 출력
                        WriteLine("1~3999 사이의 숫자만 변환할 수 있습니다.\n");
                    else //위 조건을 모두 만족하지 않을 경우 num값(변환된 아라비아 숫자) 출력
                        WriteLine("입력한 수 : " + num + "\n");
                }
            }
        }
    }
}

