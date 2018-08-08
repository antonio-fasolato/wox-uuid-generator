using System;
using System.Collections.Generic;
using Wox.Plugin;
using System.Windows.Forms;

namespace wox_uuid_generator
{
    public class Main : IPlugin
    {
        public void Init(PluginInitContext context) {
            //Init code here
        }

        public List<Result> Query(Query query) {
            var results = new List<Result>();
            var id = Guid.NewGuid().ToString();

            //Basic
            results.Add(new Result() {
                Title = id,
                SubTitle = "Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(id);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //Uppercase
            results.Add(new Result() {
                Title = id.ToUpper(),
                SubTitle = "Uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(id.ToUpper());

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //Braces
            results.Add(new Result() {
                Title = $"{{{id}}}",
                SubTitle = "With braces - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText($"{{{id}}}");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //Braces, uppercase
            results.Add(new Result() {
                Title = $"{{{id.ToUpper()}}}",
                SubTitle = "With braces, uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText($"{{{id.ToUpper()}}}");

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens
            results.Add(new Result() {
                Title = id.Replace("-", ""),
                SubTitle = "No hyphens - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(id.Replace("-", ""));

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens uppercase
            results.Add(new Result() {
                Title = id.Replace("-", "").ToUpper(),
                SubTitle = "No hyphens, uppercase - Copy to clipboard",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    Clipboard.SetText(id.Replace("-", "").ToUpper());

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            return results;
        }
    }
}
