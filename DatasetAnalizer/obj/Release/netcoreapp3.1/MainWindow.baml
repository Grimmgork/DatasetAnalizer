   M S B A M L   `   `   `  ���� J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DatasetAnalizerDatasetAnalizer  E'clr-namespace:DatasetAnalizer.ViewModelDatasetAnalizer.ViewModel  M+clr-namespace:DatasetAnalizer.View.ControlsDatasetAnalizer.View.Controls  G(clr-namespace:DatasetAnalizer.View.PagesDatasetAnalizer.View.Pages       DatasetAnalizer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:DatasetAnalizer     9vmdls'clr-namespace:DatasetAnalizer.ViewModel     @controls+clr-namespace:DatasetAnalizer.View.Controls     :views(clr-namespace:DatasetAnalizer.View.Pages       � Title$  
MainWindow��$	��450��$	��800��$	��600��$
��1100��
�������   BackgroundColor#��[   � UseLayoutRounding$
 True�� J� SnapsToDevicePixels$
 True��  TextFont#��[  � WindowStyle$
 None=� �� EdgeMode$ Aliased=� � 	Resources 3   -DatasetAnalizer.ViewModel.MainWindowViewModel  VM �� DataType6   0DatasetAnalizer.ViewModel.ImportDataSetViewModel.   (DatasetAnalizer.View.Pages.ImportDataset8  2DatasetAnalizer.ViewModel.ChooseOperationViewModel0   *DatasetAnalizer.View.Pages.ChooseOperation��%S   &	       (��      *, +)(��      *, +)  �� "  .R�  �� "  .R�  '  !System.Windows.Shell.WindowChrome   WindowChrome   -   windowChrome��   GlassFrameThickness$ 0q�	   CornerRadius$	 0��
   CaptionHeight$
 0Q�   UseAeroCaptionButtons$ False��   ResizeBorderThickness$ 7q�.���� -    ��Name$ 
MainBorder��  PrimaryColor#��[ $��0q�._��  � RowDefinitions �� $��30 ��� .+��� $��1������ *MainContent+ �� Source# [ 1   +DatasetAnalizer.View.Controls.OverlayHolder  -     Name$ OH_Main��$��1���� $��Stretch=�$
��Auto��$��0,0,0.333,0q�  ForegroundColor#��[  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   ShadowDepth$ 0Q�   
BlurRadius$ 10Q�   Opacity$	 0.3Q�   RenderingBias$ Quality=��� -   ��  �� Orientation$ 
Horizontal=�$��Right=�$��Stretch=�$��0,0,0.333,0q�$
 True��$
 True��.+��� -   $��45��$
��Auto��$	����  WindowControlButtonStyle#��[   
SymbolFont#��[ �� -    ��Name$ 
B_maximize��$��45��$
��Auto��$	����#��[ $��12(�#��[ �� -   $��45��$
��Auto��$	����  WindowCloseButtonStyle#��[ #��[ �� $ 
Horizontal=�$
��Left=�$��Stretch=�$
 True��$
 True��.+��� $��50��$
��Auto��$	����#��[ #��[ ���� *clearAllCommand+# [ �� $��50��$
��Auto��$	����#��[ #��[ ���� *clearAllCommand+# [ �� $��DatasetAnalizer��$
��Left=�$��10,0,0,0q�$��Center=�  TextDarkColor#��[  J� IsHitTestVisible$ False���� -   $��lvUsers��$��10q�$��1�� �� View ��  %� VirtualizationMode$ 	Recycling=�.P��� $
��Name�� �� Width$	 120�� �� DisplayMemberBinding �� *A+�� $	��Age��$ 50�� �� *B+�� $
��Mail��$	 150�� �� *C+�� $
��Mail��$	 150�� �� *D+�� $
��Mail��$	 150�� �� *E+�� $
��Mail��$	 150�� �� *F+�� $
��Mail��$	 150�� �� *G+�� $
��Mail��$	 150�� �� *H+�� $
��Mail��$	 150�� �� *I+�� $
��Mail��$	 150�� �� *J+�� $
��Mail��$	 150�� �� *K+