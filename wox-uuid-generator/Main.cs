using System;
using System.Collections.Generic;
using Wox.Plugin;
using System.Windows.Forms;
using System.Linq;

namespace wox_uuid_generator
{
    public class Main : IPlugin
    {
        public void Init(PluginInitContext context) {
            //Init code here
        }

        public List<Result> Query(Query query) {
            var results = new List<Result>();
            var ids = new List<string>();

            int count = 1;

            if(query.Terms.Count() > 1) {
                int x = 0;
                if(int.TryParse(query.Terms[1], out x)) {
                    count = x;
                }
            }

            for (int i = 0; i < count; ++i) {
                ids.Add(Guid.NewGuid().ToString());
            }

            //Basic
            results.Add(new Result() {
                Title = String.Join(", ", ids),
                SubTitle = "Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", ids) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            var uppercase = ids.Select(t => t.ToUpper());
            //Uppercase
            results.Add(new Result() {
                Title = String.Join(", ", uppercase),
                SubTitle = "Uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", uppercase) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            var braces = ids.Select(t => $"{{{t}}}");
            //Braces
            results.Add(new Result() {
                Title = String.Join(", ", braces),
                SubTitle = "With braces - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", braces) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //Braces, uppercase
            var uppercaseBraces = ids.Select(t => $"{{{t.ToUpper()}}}");
            results.Add(new Result() {
                Title = String.Join(", ", uppercaseBraces),
                SubTitle = "With braces, uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", uppercaseBraces) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens
            var noHyphens = ids.Select(t => t.Replace("-", ""));
            results.Add(new Result() {
                Title = String.Join(", ", noHyphens),
                SubTitle = "No hyphens - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", noHyphens) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens uppercase
            var uppercaseNoHyphens = ids.Select(t => t.Replace("-", "").ToUpper());
            results.Add(new Result() {
                Title = String.Join(", ", uppercaseNoHyphens),
                SubTitle = "No hyphens, uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(String.Join("\n", uppercaseNoHyphens) + "\n");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            return results;
        }
    }
}
