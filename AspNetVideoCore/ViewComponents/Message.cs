using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetVideoCore.ViewComponents
{
    public class Message: ViewComponent
    {
        private IMessageService _message;

        public Message(IMessageService message)
        {
            _message = message;
        }

        public IViewComponentResult Invoke()  // consider using async later
        {
            var model = _message.GetMessage();
            return View("Default", model);
        }

 

    }
}
