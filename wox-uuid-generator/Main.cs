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
            return results;
        }
    }
}
