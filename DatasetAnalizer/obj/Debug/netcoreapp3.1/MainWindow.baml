   M S B A M L   `   `   `  ����J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DatasetAnalizerDatasetAnalizer  5   	   E'clr-namespace:DatasetAnalizer.ViewModelDatasetAnalizer.ViewModel  5   	   ;"clr-namespace:DatasetAnalizer.ViewDatasetAnalizer.View  5	   	   K*clr-namespace:DatasetAnalizer.DialogSystemDatasetAnalizer.DialogSystem  5
   	   C&clr-namespace:DatasetAnalizer.ControlsDatasetAnalizer.Controls  5   	        DatasetAnalizer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DatasetAnalizer     5   	   9vmdls'clr-namespace:DatasetAnalizer.ViewModel     5   	   4views"clr-namespace:DatasetAnalizer.View     5	   	   =dialog*clr-namespace:DatasetAnalizer.DialogSystem     5
   	   ;controls&clr-namespace:DatasetAnalizer.Controls     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��5   	   $	��800��6   $	��700��5   	   $
��1100��6      BackgroundColor#��[  5   	    � UseLayoutRounding$
 True��5   	    J� SnapsToDevicePixels$
 True��5   	     TextFont#��[ 5   	    � WindowStyle$
 None=�5   	    �� EdgeMode$ Aliased=�5   	    � WindowState$ Normal=�5   	    � 	Resources 5      3   -DatasetAnalizer.ViewModel.MainWindowViewModel  VM �� DataType6   0DatasetAnalizer.ViewModel.ImportDataSetViewModel(   "DatasetAnalizer.View.ImportDataset8  2DatasetAnalizer.ViewModel.ChooseOperationViewModel*   $DatasetAnalizer.View.ChooseOperation��%�   &	       (��      5      *, +)(�� E     5!      *, +)  5   
   6$   �� 5   
   "  6   .R�5        5      �� 5!   
   "  6   .R�5"        5#      5%      '  !System.Windows.Shell.WindowChrome   WindowChrome 5'        5(   
   -   5        windowChrome��	   GlassFrameThickness$	 0q�5(   -   
   CornerRadius$
 0��6E      CaptionHeight$ 0Q�6V      UseAeroCaptionButtons$ False��6h      ResizeBorderThickness$ 4q�6�   .��5+      �� -   5         ��Name$ 
MainBorder��5+        PrimaryColor#��[ 6!   $��0q�6M   ._�5,   
   �  � RowDefinitions 5-      �� 5.      $��32 �6    �� 5/      $
��Auto �6    �� 50      �� 51      $��24 �6    .+�54      �� $��1��6   $��2��6,   ��6=   �� *MainContent+ �� Source# [ �� 56      $��1��6    J� Opacity$
 0.15Q�6%   $��8��64   ��57      �� 58       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 0,1&�6;   .��59      �  � Color$ Black��6'    � Offset$ 0Q�65   � 5:      $ 	#00000000��6'   $ 1Q�69   5;      5=      �� 5?      $��3��6     ForegroundColor#��[ 6"   ._�5@      �� #��[ 6   $��2q�6J   .@�5A      �� .��5B      �� $��Hello there!��6$   $��Center=�68   $��11(�6S   $��Medium"�6a   #��[ 6v   5C      5D      5E      0   *DatasetAnalizer.DialogSystem.OverlayHolder  5G      $��1��6#   $��4��60   �� 5I      $��Stretch=�6   $
��Auto��62   #��[ 6?   �� 5K      -   5        5K      �� 5M       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Stretch=�6N   $��0,0,0.333,0q�6j   $
 True��6   $
 True��6�   .+�5N      �� -   5        $��40��5N      $	����6$     TransparentButtonStyle#��[ 6U     
SymbolFont#��[ 6�   �� 5O      -   5         ��Name$ 
B_maximize��5O      $��40��6-   $	����69   #��[ 6j   $��12(�6�   #��[ 6�   �� 5P      -   5        $��40��5P      $	����6%   #��[ 6S   #��[ 6�   5Q      �� 5S      $ 
Horizontal=�6   $
��Left=�62   $��Stretch=�6M   $
 True��6i   $
 True��6�   .+�5V      �� $��40��6   $	����6$   #��[ 67   #��[ 6g   ��6�   �� *clearAllCommand+# [ 5X      �� 5Z      $	��csv��6   $��Center=�6#   $��15(�6@   $��8,0,0,0q�6N   $��Center=�6_     TextDarkColor#��[ 6z    J� IsHitTestVisible$ False��6�   $��Medium"�6�   5]      5^      5_      