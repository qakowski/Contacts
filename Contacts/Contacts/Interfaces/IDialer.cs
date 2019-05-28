using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
   public interface IDialer
    {
        bool Dial(string number);
    }
}
