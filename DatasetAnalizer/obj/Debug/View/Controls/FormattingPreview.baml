   M S B A M L   `   `   `  ����J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:DatasetAnalizer.View.ControlsDatasetAnalizer.View.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5      5    /DatasetAnalizer.View.Controls.FormattingPreview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:DatasetAnalizer.View.Controls     5      Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     5      -   5        $��formattingPreviewControl��5	        � 	Resources  5         DT_Text � ColumnDefinitions  
SymbolFont  
ErrorColor ^� InitialShowDelay ^� ShowDuration ^� BetweenShowDelay  	BoolToVis �� 	Converter � ToolTip �� 
TargetType �� Property	 �� Value
 �� Triggers �� Binding �� Value  SuccessColor+   %DatasetAnalizer.View.Controls.TextRow+   %DatasetAnalizer.View.Controls.TextRow   	MouseMove   
MouseLeave
   Row  HeaderBackgroundOpacityMask �� 
StartPoint �� EndPoint � Color � Offset��%1  &	        7  7  7  7  7  &	 q    �� 5   
   .R�5      �  5      �� 5      $��20 �6'   �� 5      $��5 �6'   �� 5      .+�5      �� 8��  $	����6�   8�� $��Center=�6�   $��Center=�6�   $��0��6  $	 100��6  $
 5000��69  $	 500��6\  y�6   �� *HasComplication+8   6�  �� *ComplicationDescription+�� 5      $��1��6   ��5      �� 5      " ��6    .�5      ��  � ��
	 ���� 6;   
 5      �� 5   "    6.   �� *
IsObject+ True6K   .a�5   &   ��  � ��8	  6C   5    #   �� 5"   "    6.   �� *HasComplication+ True6R   .a�5#   &   ��  � ��8	  6C   5$   #   5&      5(        5*       LB_ItemMouseMove6�    LB_ItemMouseLeave6�   $��3��6    $
��5000��60   $��5,0,0,0q�6=   $��20��6N   $
��Left=�6o   $��Center=�6�    6Z   �� *This+6�   5+      5,      �� 5.   
   $	 0,1&�6B   $	 0,0&�6S   .��5/      � $ 	#FFFFFFFF��6   $ 0Q�6-   � 50      $ 	#0FFFFFFF��6   $ 1Q�6-   51      52      .��54      � .+�55   
   �  � RowDefinitions 56      �� 57      �� 58      $
��Auto �6    .+�5<      �� -   5         ��Name$ LB��5<   [    � UseLayoutRounding .  #��[  6g    �� SelectionMode$ Single=�6�   $��Disabled=�6�   ��60   �� *Rows+ �� IsAsync . ��5=      �� 5>      " ��6   �5?      �� 5@       � ��	 5A   "   �� 5B   &    �� 
TargetType" ��66   .R�5D   *   ��  ��Name$ Bd��61   
������ ._�5E   .   �� 5F   +    �� Triggers 5H   *   P� 5I   .    P� Property �@J�IsMouseOver P� Value . . �5J   2   ��  �� 
TargetName$ Bd��69     HighlightColor#	 [ 6_    � ��5K   /   5M   '   5O      5Q      5S      �� 5U      -   5         ��Name$
 CANV��5U        J� IsHitTestVisible  .  }�. $��0,0,15,0q�6P   5V      � 5Y   
   -   5        ! �Name$! ProcessingOverlay��5Y      $y�Hidden=�6*     .  .+�5Z      �� 
���   �" J� Opacity$	" 0.8Q�6(   �� 5[      $��Processing...��6   $��15(�6-     TextLightColor#��[ 6;   $��Center=�6h   $��Center=�6�   5\      5]      5_      