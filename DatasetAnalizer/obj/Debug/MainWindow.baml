   M S B A M L   `   `   `  ����J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DatasetAnalizerDatasetAnalizer  5   	   E'clr-namespace:DatasetAnalizer.ViewModelDatasetAnalizer.ViewModel  5   	   M+clr-namespace:DatasetAnalizer.View.ControlsDatasetAnalizer.View.Controls  5   	   G(clr-namespace:DatasetAnalizer.View.PagesDatasetAnalizer.View.Pages  5	   	        DatasetAnalizer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DatasetAnalizer     5   	   9vmdls'clr-namespace:DatasetAnalizer.ViewModel     5   	   @controls+clr-namespace:DatasetAnalizer.View.Controls     5   	   :views(clr-namespace:DatasetAnalizer.View.Pages     5	   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��500��65   $	��850��6E   
�������   BackgroundColor#��[  6f    � UseLayoutRounding .  J� SnapsToDevicePixels .   TextFont#��[ 6�    � WindowStyle$
 None=�6�    �� EdgeMode$ Aliased=�6   � 	Resources 5      3   -DatasetAnalizer.ViewModel.MainWindowViewModel  VM �� DataType6   0DatasetAnalizer.ViewModel.ImportDataSetViewModel.   (DatasetAnalizer.View.Pages.ImportDataset8  2DatasetAnalizer.ViewModel.ChooseOperationViewModel0   *DatasetAnalizer.View.Pages.ChooseOperation��%�   &	       (��      5      *, +)(�� E     5      *, +)  5   
   6$   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   -   5        windowChrome��   GlassFrameThickness$ 0q�5   -   	   CornerRadius$	 0��6E   
   CaptionHeight$
 0Q�6V      UseAeroCaptionButtons .     ResizeBorderThickness$ 7q�6�   .��5      �� -   5         ��Name$ 
MainBorder��5        PrimaryColor#��[ 6!   $��0q�6M   ._�5   
   �  � RowDefinitions 5      �� 5       $��30 �6    �� 5!      .+�5$      �� $��1��6   ��6,   �� *MainContent+ �� Source# [ 1   +DatasetAnalizer.View.Controls.OverlayHolder  5%      -   5          Name$ OH_Main��5%   2   $��1��6%   62   �� 5'      $��Stretch=�6   $
��Auto��62   $��0,0,0.333,0q�6?     ForegroundColor#��[ 6T    J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)         Color$ Black��6'      ShadowDepth$ 0Q�66      
BlurRadius$ 10Q�6F      Opacity$	 0.3Q�6V      RenderingBias$ Quality=�6d   5+      �� 5-      -   5        5-      �� 5/       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Stretch=�6N   $��0,0,0.333,0q�6j    .  . .+�50      �� -   5        $��45��50      $
��Auto��6$   $	����62     WindowControlButtonStyle#��[ 6c     
SymbolFont#��[ 6�   �� 51      -   5         ��Name$ 
B_maximize��51      $��45��6-   $
��Auto��68   $	����6F   #��[ 6w   $��12(�6�   #��[ 6�   �� 52      -   5        $��45��52      $
��Auto��6$   $	����62     WindowCloseButtonStyle#��[ 6`   #��[ 6�   53      �� 55      $ 
Horizontal=�6   $
��Left=�62   $��Stretch=�6M    .  . .+�56      �� $��50��6   $
��Auto��6$   $	����62   #��[ 6E   #��[ 6w   ��6�   �� *clearAllCommand+# [ 57      58      59      5:      