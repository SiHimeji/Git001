using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw
{
    static public class ClassCw
    {
        static string[] dot =  { "�E�|", "-�E�E�E", "-�E-�E", "-�E�E", "�E", "�E�E�|�E", "--�E", "�E�E�E�E", "�E�E", "�E�|�|�|", "�|�E�|", "�E�|�E�E", "�|�|", "-�E", "�|�|�|", "�E�|�|�E", "�|�|�E�|", "�E�|�E", "�E�E�E", "�|", "�E�E�|", "�E�E�E�|", "�E�|�|", "�|�E�E�|", "�|�E�|�|", "--�E�E", "�E�|�|�|�|", "�E�E�|�|�|", "�E�E�E�|�|", "�E�E�E�E�|", "�E�E�E�E�E", "-�E�E�E�E", "--�E�E�E", "---�E�E", "----�E", "�|�|�|�|�|" };
        static string[] moji = { "A"   , "B"      , "C"     , "D"    , "E" , "F"       , "G"   , "H"       , "I"   , "J"       , "K"     , "L"       , "M"   , "N"  , "O"     , "P"       , "Q"       , "R"     , "S"     , "T"  , "U"    , "V"       , "W"     , "X"       , "Y"       , "Z"     , "1"         , "2"         , "3"         , "4"         , "5"         , "6"        , "7"       , "8"      , "9"     , "0" };


        static public string dot2moji(string buf)
        {
            return moji[GetHairetu(buf, dot)];
        }
        static public string moji2dot(string buf)
        {
            return dot[GetHairetu(buf, moji)];
        }
        static private int GetHairetu(string nm, string[] retumei)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;
        }




    }
}
