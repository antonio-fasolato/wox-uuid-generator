﻿using System;
using System.Text;
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
            bool base64 = false;
            bool v1 = false;

            int count = 1;

            for(int i = 1; i < query.Terms.Count(); ++i) {
                string opt = query.Terms[i];
                if (opt.ToUpper() == "B") {
                    base64 = true;
                }
                if (opt.ToUpper() == "V1") {
                    v1 = true;
                } else {
                    int x = 0;
                    if (int.TryParse(opt, out x)) {
                        count = x;
                    }
                }
            }

            for (int i = 0; i < count; ++i) {
                if (v1) {
                    ids.Add(NewSequentialGuid().ToString());
                } else {
                    ids.Add(Guid.NewGuid().ToString());
                }
            }

            //Basic
            results.Add(new Result() {
                Title = String.Join(", ", ids),
                SubTitle = $"Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if(base64) {
                        result = String.Join("\n", ids.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", ids) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            var uppercase = ids.Select(t => t.ToUpper());
            //Uppercase
            results.Add(new Result() {
                Title = String.Join(", ", uppercase),
                SubTitle = $"Uppercase - Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if (base64) {
                        result = String.Join("\n", uppercase.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", uppercase) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            var braces = ids.Select(t => $"{{{t}}}");
            //Braces
            results.Add(new Result() {
                Title = String.Join(", ", braces),
                SubTitle = $"With braces - Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if (base64) {
                        result = String.Join("\n", braces.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", braces) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //Braces, uppercase
            var uppercaseBraces = ids.Select(t => $"{{{t.ToUpper()}}}");
            results.Add(new Result() {
                Title = String.Join(", ", uppercaseBraces),
                SubTitle = $"With braces, uppercase - Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if (base64) {
                        result = String.Join("\n", uppercaseBraces.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", uppercaseBraces) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens
            var noHyphens = ids.Select(t => t.Replace("-", ""));
            results.Add(new Result() {
                Title = String.Join(", ", noHyphens),
                SubTitle = $"No hyphens - Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if (base64) {
                        result = String.Join("\n", noHyphens.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", noHyphens) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            //no-hyphens uppercase
            var uppercaseNoHyphens = ids.Select(t => t.Replace("-", "").ToUpper());
            results.Add(new Result() {
                Title = String.Join(", ", uppercaseNoHyphens),
                SubTitle = $"No hyphens, uppercase - Copy to clipboard{(base64 ? " Base64 encoded" : "")}",
                IcoPath = "Images\\icon.png",  //relative path to your plugin directory
                Action = e => {
                    // after user selects the item
                    var result = "";
                    if (base64) {
                        result = String.Join("\n", uppercaseNoHyphens.Select(b => Convert.ToBase64String(Encoding.UTF8.GetBytes(b)))) + "\n";
                    } else {
                        result = String.Join("\n", uppercaseNoHyphens) + "\n";
                    }
                    Clipboard.SetText(result);

                    // return false to tell Wox not to hide thequery window, otherwise Wox will hide it automatically
                    return true;
                }
            });

            return results;
        }

        private static Guid NewSequentialGuid() {
            GUIDDATA guiddata;

            if ((UuidCreateSequential(out guiddata) & 0x80000000) != 0) // FAILED(hr)  
                throw new InvalidOperationException();
            return new Guid(guiddata.Data1, guiddata.Data2, guiddata.Data3, guiddata.Data4);
        }

        #region API  
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct GUIDDATA
        {
            public int Data1;
            public short Data2;
            public short Data3;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Data4;
        }

        [System.Runtime.InteropServices.DllImport("rpcrt4.dll")]
        private static extern int UuidCreateSequential(out GUIDDATA Uuid);
        #endregion
    }
}
