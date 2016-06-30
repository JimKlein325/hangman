using Nancy;
using System.Collections.Generic;
using Hangman.Objects;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["welcome.cshtml"];

      Post["/new_game"] = _ => {
        Game newGame = new Game();
        return View["hangman.cshtml",newGame];
      };

      // Post["/guess"] = _ => {
      //
      // };
      //
      //
      // }
    }
  }
}
