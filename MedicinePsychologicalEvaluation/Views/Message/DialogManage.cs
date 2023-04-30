using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Views
{
    public static class DialogManage
    {
        private static readonly Dictionary<DialogType, Alert> _dialogBase = new();

        public static void Show(DialogType type, string content,WindowStartupLocation location = WindowStartupLocation.CenterScreen, int height = 100, int width = 200, int timing = 3000)
        {
            Alert dialog;
            lock (_dialogBase)
            {
                if (_dialogBase.Remove(type, out var dialogBase))
                {
                    try
                    {
                        dialogBase.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                dialog = new Alert
                {
                    Height = height,
                    Width = width,
                    WindowStartupLocation = location
                };

                if (timing > 0)
                {
                    // 弹窗定时关闭
                    _ = Task.Run(async () =>
                    {
                        await Task.Delay(timing);
                        // 先删除并且拿到删除的value
                        if (_dialogBase.Remove(type, out var dialogBase))
                        {
                            _ = Dispatcher.UIThread.InvokeAsync(() =>
                            {
                                try
                                {
                                    dialogBase.Close();
                                }
                                catch (Exception)
                                {
                                }
                            });
                        }
                    });
                }

                _dialogBase.TryAdd(type, dialog);
            }

            // 获取当前屏幕
            var bounds = dialog.Screens.ScreenFromVisual(dialog).Bounds;

            // 偏移
            int skewing = 20;

            // Windows的任务栏高度
            int taskBar = 50;

            int m, n;
            switch (type)
            {
                case DialogType.TopLet:
                    m = skewing;
                    n = skewing;
                    break;
                case DialogType.TopCenter:
                    m = (int)((bounds.Width - dialog.Width) / 2);
                    n = skewing;
                    break;
                case DialogType.TopRight:
                    m = (int)((bounds.Width - dialog.Width)- skewing);
                    n = skewing;
                    break;
                case DialogType.LeftLower:
                    m = skewing;
                    n = (int)((bounds.Height - dialog.Height) - taskBar - skewing);
                    break;
                case DialogType.CenterLower:
                    m = (int)((bounds.Width - dialog.Width) / 2);
                    n = (int)((bounds.Height - dialog.Height) - taskBar - skewing);
                    break;
                case DialogType.RightLower:
                    m = (int)(bounds.Width - dialog.Width - skewing);
                    n = (int)(bounds.Height - dialog.Height) - taskBar - skewing;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            // 设置弹窗位置
            dialog.Position = new PixelPoint(m, n);
            // 获取内容显示的组件并且将内容显示上去
            var contentBox = dialog.Find<TextBlock>("Content");
            contentBox.Text = content;
            dialog.Show();
        }

    }

    public enum DialogType
    {
        /// <summary>
        /// 左上
        /// </summary>
        TopLet,

        /// <summary>
        /// 居中靠上
        /// </summary>
        TopCenter,

        /// <summary>
        /// 右上
        /// </summary>
        TopRight,

        /// <summary>
        /// 左下
        /// </summary>
        LeftLower,

        /// <summary>
        /// 居中靠下
        /// </summary>
        CenterLower,

        /// <summary>
        /// 右下
        /// </summary>
        RightLower
    }

}
