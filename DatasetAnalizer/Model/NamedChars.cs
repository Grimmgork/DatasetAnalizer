using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatasetAnalizer.Model
{
    public static class NamedChars
    {
        static string[] lookup = new string[128];

        static NamedChars()
        {
            lookup[0x00] = "Null character";
            lookup[0x01] = "Start of Heading";
            lookup[0x02] = "Start of Text";
            lookup[0x03] = "End-of-text";
            lookup[0x04] = "End-of-transmission";
            lookup[0x05] = "Enquiry";
            lookup[0x06] = "Acknowledge";
            lookup[0x07] = "Bell";
            lookup[0x08] = "Backspace";
            lookup[0x09] = "Horizontal tab";
            lookup[0x0A] = "Line feed";
            lookup[0x0B] = "Vertical tab";
            lookup[0x0C] = "Form feed";
            lookup[0x0D] = "Carriage return";
            lookup[0x0E] = "Shift Out";
            lookup[0x0F] = "Shift In";
            lookup[0x10] = "Data Link Escape";
            lookup[0x11] = "Device Control 1";
            lookup[0x12] = "Device Control 2";
            lookup[0x13] = "Device Control 3";
            lookup[0x14] = "Device Control 4";
            lookup[0x15] = "Not-acknowledge";
            lookup[0x16] = "Synchronous Idle";
            lookup[0x17] = "End of Transmission Block";
            lookup[0x18] = "Cancel";
            lookup[0x19] = "End of Medium";
            lookup[0x1A] = "Substitute";
            lookup[0x1B] = "Escape";
            lookup[0x1C] = "File Separator";
            lookup[0x1D] = "Group Separator";
            lookup[0x1E] = "Record Separator";
            lookup[0x1F] = "Unit Separator";
            lookup[0x20] = "Space";
            lookup[0x21] = "Exclamation mark";
            lookup[0x22] = "Quotation mark";
            lookup[0x23] = "Number sign";
            lookup[0x24] = "Dollar sign";
            lookup[0x25] = "Percent sign";
            lookup[0x26] = "Ampersand";
            lookup[0x27] = "Apostrophe";
            lookup[0x28] = "Left parenthesis";
            lookup[0x29] = "Right parenthesis";
            lookup[0x2A] = "Asterisk";
            lookup[0x2B] = "Plus sign";
            lookup[0x2C] = "Comma";
            lookup[0x2D] = "Hyphen-minus";
            lookup[0x2E] = "Full stop";
            lookup[0x2F] = "Slash";
            lookup[0x30] = "Digit Zero";
            lookup[0x31] = "Digit One";
            lookup[0x32] = "Digit Two";
            lookup[0x33] = "Digit Three";
            lookup[0x34] = "Digit Four";
            lookup[0x35] = "Digit Five";
            lookup[0x36] = "Digit Six";
            lookup[0x37] = "Digit Seven";
            lookup[0x38] = "Digit Eight";
            lookup[0x39] = "Digit Nine";
            lookup[0x3A] = "Colon";
            lookup[0x3B] = "Semicolon";
            lookup[0x3C] = "Less-than sign";
            lookup[0x3D] = "Equal sign";
            lookup[0x3E] = "Greater-than sign";
            lookup[0x3F] = "Question mark";
            lookup[0x40] = "At sign";
            lookup[0x41] = "Latin Capital Letter A";
            lookup[0x42] = "Latin Capital Letter B";
            lookup[0x43] = "Latin Capital Letter C";
            lookup[0x44] = "Latin Capital Letter D";
            lookup[0x45] = "Latin Capital Letter E";
            lookup[0x46] = "Latin Capital Letter F";
            lookup[0x47] = "Latin Capital Letter G";
            lookup[0x48] = "Latin Capital Letter H";
            lookup[0x49] = "Latin Capital Letter I";
            lookup[0x4A] = "Latin Capital Letter J";
            lookup[0x4B] = "Latin Capital Letter K";
            lookup[0x4C] = "Latin Capital Letter L";
            lookup[0x4D] = "Latin Capital Letter M";
            lookup[0x4E] = "Latin Capital Letter N";
            lookup[0x4F] = "Latin Capital Letter O";
            lookup[0x50] = "Latin Capital Letter P";
            lookup[0x51] = "Latin Capital Letter Q";
            lookup[0x52] = "Latin Capital Letter R";
            lookup[0x53] = "Latin Capital Letter S";
            lookup[0x54] = "Latin Capital Letter T";
            lookup[0x55] = "Latin Capital Letter U";
            lookup[0x56] = "Latin Capital Letter V";
            lookup[0x57] = "Latin Capital Letter W";
            lookup[0x58] = "Latin Capital Letter X";
            lookup[0x59] = "Latin Capital Letter Y";
            lookup[0x5A] = "Latin Capital Letter Z";
            lookup[0x5B] = "Left Square Bracket";
            lookup[0x5C] = "Backslash";
            lookup[0x5D] = "Right Square Bracket";
            lookup[0x5E] = "Circumflex accent";
            lookup[0x5F] = "Low line";
            lookup[0x60] = "Grave accent";
            lookup[0x61] = "Latin Small Letter A";
            lookup[0x62] = "Latin Small Letter B";
            lookup[0x63] = "Latin Small Letter C";
            lookup[0x64] = "Latin Small Letter D";
            lookup[0x65] = "Latin Small Letter E";
            lookup[0x66] = "Latin Small Letter F";
            lookup[0x67] = "Latin Small Letter G";
            lookup[0x68] = "Latin Small Letter H";
            lookup[0x69] = "Latin Small Letter I";
            lookup[0x6A] = "Latin Small Letter J";
            lookup[0x6B] = "Latin Small Letter K";
            lookup[0x6C] = "Latin Small Letter L";
            lookup[0x6D] = "Latin Small Letter M";
            lookup[0x6E] = "Latin Small Letter N";
            lookup[0x6F] = "Latin Small Letter O";
            lookup[0x70] = "Latin Small Letter P";
            lookup[0x71] = "Latin Small Letter Q";
            lookup[0x72] = "Latin Small Letter R";
            lookup[0x73] = "Latin Small Letter S";
            lookup[0x74] = "Latin Small Letter T";
            lookup[0x75] = "Latin Small Letter U";
            lookup[0x76] = "Latin Small Letter V";
            lookup[0x77] = "Latin Small Letter W";
            lookup[0x78] = "Latin Small Letter X";
            lookup[0x79] = "Latin Small Letter Y";
            lookup[0x7A] = "Latin Small Letter Z";
            lookup[0x7B] = "Left Curly Bracket";
            lookup[0x7C] = "Vertical bar";
            lookup[0x7D] = "Right Curly Bracket";
            lookup[0x7E] = "Tilde";
            lookup[0x7F] = "Delete";
        }

        public static string[] GetNames()
        {
            return lookup;
        }

        public static string GetName(char c)
        {
            return lookup[(byte)c];
        }

        public static char GetChar(byte i)
        {
            return (char)i;
        }
    }
}
