   M S B A M L   `   `   `  ���� J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:DatasetAnalizer.View.ControlsDatasetAnalizer.View.Controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5    /DatasetAnalizer.View.Controls.FormattingPreview   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:DatasetAnalizer.View.Controls     Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     -   $��formattingPreviewControl��  � 	Resources     DT_Text � ColumnDefinitions  
SymbolFont  
ErrorColor ^� InitialShowDelay ^� ShowDuration ^� BetweenShowDelay  	BoolToVis �� 	Converter � ToolTip �� 
TargetType �� Property	 �� Value
 �� Triggers �� Binding �� Value  SuccessColor+   %DatasetAnalizer.View.Controls.TextRow+   %DatasetAnalizer.View.Controls.TextRow   	MouseMove   
MouseLeave
   Row  HeaderBackgroundOpacityMask �� 
StartPoint �� EndPoint � Color � Offset��%�  &	        7  7  7  7  7  &	     �� .R��  �� $��20 ��� $��5 ��� .+��� 8��  $	����8�� $��Center=�$��Center=�$��0��$	 100��$
 5000��$	 500��y��� *HasComplication+8   �� *ComplicationDescription+�� $��1������ " ��.���  � ��
	 ���� 
 ��  �� *
IsObject+ True.a���  � ��8	  ��  �� *HasComplication+ True.a���  � ��8	     LB_ItemMouseMove LB_ItemMouseLeave$��3��$
��5000��$��5,0,0,0q�$��20��$
��Left=�$��Center=� �� *This+�� $	 0,1&�$	 0,0&�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#0FFFFFFF��$ 1Q�.��� .+��  � RowDefinitions �� �� $
��Auto �.+��� -    ��Name$ LB�� � UseLayoutRounding$ False��#��[   �� SelectionMode$ Single=�$��Disabled=����� *Rows+ �� IsAsync$
 True������ " �����  � ��	 ��  �� 
TargetType" ��.R���  ��Name$ Bd��
������ ._�� .+��� $	 Bds��$��2q���  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ Bd��  HighlightColor#	 [  � ��P�  �@��
IsSelected$
 True��. ��� $	 Bds��  PrimaryColor#	 [  � ���� -    ��Name$
 CANV��  J� IsHitTestVisible$  False��$
}�True��$��0,0,15,0q�� -   ! �Name$! ProcessingOverlay��$y�Hidden=�$  False��.+��� 
���   �" J� Opacity$	" 0.8Q��� $��Processing...��$��15(�  TextLightColor#��[ $��Center=�$��Center=�