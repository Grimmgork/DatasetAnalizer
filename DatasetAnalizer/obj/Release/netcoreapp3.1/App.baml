   M S B A M L   `   `   `  ���� J  FDatasetAnalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DatasetAnalizerDatasetAnalizer  E'clr-namespace:DatasetAnalizer.ViewModelDatasetAnalizer.ViewModel  G(clr-namespace:DatasetAnalizer.View.PagesDatasetAnalizer.View.Pages      DatasetAnalizer.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:DatasetAnalizer     9vmdls'clr-namespace:DatasetAnalizer.ViewModel     :views(clr-namespace:DatasetAnalizer.View.Pages       �� 	Resources     PrimaryColor �� Color  
ErrorColor  SuccessColor  WarningColor  BackgroundColor  ForegroundColor  HighlightColor  TextNormalColor  TextDarkColor 	 TextLightColor 
 ScrollbarColor  ScrollbarHighlightColor  
SymbolFont  TextFont  	BoolToVis  DefaultButtonSytle �� 
TargetType �� Property �� Value �� 
TargetType ��Name � UseLayoutRounding J� Effect3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   	Direction   Color   Opacity   RenderingBias ��Name �� Triggers P� Property P� Value �� 
TargetName �� RelativeSource �� Path �� BasedOn  WindowControlButtonStyle ��Name  WindowCloseButtonStyle  TransparentButtonStyle � RowDefinitions  FlatListBoxItemBase K� IsItemsHost ��Name  ComboBoxToggleButton � ColumnDefinitions F�Name  ComboBoxTextBox �� 	ClickMode d� 	IsChecked �� Mode  J� IsHitTestVisible! �� SelectionBoxItem" �� SelectionBoxItemTemplate# ��Name$ �� 
IsReadOnly% �� 
IsReadOnly& �� IsDropDownOpen' � AllowsTransparency( J� SnapsToDevicePixels) � ActualWidth* �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation+   DirectionalNavigation, P� 
SourceName- �� Triggers. ��Name  ScrollBarLineButton  ScrollBarPageButton  ScrollBarThumb  VerticalScrollBar/ ]�Name0 ]� DecreaseRepeatButton1 ]� Thumb2 ]� IncreaseRepeatButton  HorizontalScrollBar   ScrollViewerControlTemplate13 �Name4 ��Name5 �� CanContentScroll6 �� CanHorizontallyScroll7 �� CanVerticallyScroll8 ��Name4  .System.Windows.Automation.AutomationProperties9   AutomationId: � Cursor; �� ScrollableHeight< � Maximum= � Minimum*> �� #ComputedVerticalScrollBarVisibility? �� ViewportHeight@ �� ViewportSizeA � ValueB �� ScrollableWidthC �� Orientation,D �� %ComputedHorizontalScrollBarVisibilityE �� ViewportWidth��%�$  &	        &	      &	 &     &	 9     &	 N     &	 a     &	 t     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 1    &	 n    &	 s    7   7  7  7  7  7  '�� 7    7  &	 F    7  7   &	 o    7  7  &	 @    7  7   7 	 '�� �    7  7  7  &	 �    7  7   '�� 
    7  7  '�� �
    7   7  '�� U    7  7  7   7 	 &	     7  7  7   7  7   &	 �    '�� �    7 	 7  7  7  7   '�� m    7 	 7   '�� �    7 	 7 	 7  7  7   7   7  &	 9    7  7  7  7  &	 �    7  &	 a    7 
 7  &	 u    7  7  7  7  7  &	 �    7  7  7  7  7  '�� ^    7  7  '�� �    &	 �    �� $ #3705ff���� $ #E81123���� $ #03fc52���� $ 	#FFEDC819���� $ #121417���� $ #171a1f���� $ #21252b���� $ #A4A4A4���� $ 	#FF565656���� $ 
WhiteSmoke���� $ #21252b���� $ 	#FF2C3138��*�>:pack://application:,,,/Resources/Fonts/#remixicon Standart)�*�73pack://application:,,,/Resources/Fonts/#Nunito Sans)��� �� " ��.���  � ��8   ��  � ��$ 15(���  �@�UseLayoutRounding$
 True����  �@J�SnapsToDevicePixels$
 True����  � �� �� " ��.R��� $ bd��8�� $��1q�8�� $��25��$
 True��   $	 10Q�$
 3Q�$	 -90Q�$ Black��$	 0.1Q�$ Quality=�._��� $ MyContentPresenter��#��z��$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ bd�� ��  �� *TemplatedParent+$ 
Foreground� � ��P�  � ��$
 True��. ��� $ bd�� ��  �� *TemplatedParent+$ 
Foreground� � ��P�  � {�$ False��. ��� $ bd��8   � ���� $ bd��8   � ���� $ MyContentPresenter��8   � ���� " ��8   �� " ��.���  � ��
 ���� ��  � ��
 �������  � ��$ 15(���  � �� �� " ��.R��� #��z��._��� $ MyContentPresenter��#��z��$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 8    � ��P�  � ��$
 True��. ��� 8   � ���� 8   " ��.���  � �� �� " ��.R��� #��z��._�� .+��� $ MyContentPresenter��#��z��$��Center=�$��Center=�$��0,0,0,0q� P�  �@J�IsMouseOver$
 True��. ��� 8   � ���� " ��.���  � ��
 ���� ��  � ��
 �������  � ��$ 15(���  � ��$ Normal"���  � �� �� " ��.R��� #��z��$��1q�#��z��._��� $ MyContentPresenter��#��z��$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 8    � ��P�  � ��$
 True��. ��� 8   � ���� $ MyContentPresenter��8   � ��P�  � {�$ False��. ���  � ��
 �iii��� " ��.���  � �� �� " ��.R��� $��0��$��2��$��0q�._��  �� $
��Auto ��� $��* �.+��� 8��  8�� $��13(�.���� $��Header��$
��True��$��Stretch=��� 8�� $��1���� $��1��$��10q��� " �����  � �� �� " ��.R��� $ Bd��#��z��._��� $��1�� P�  �@J�IsMouseOver$
 True��. ��� $ Bd��8    � ��P�  �@J�IsMouseOver$ False��. ��� $ Bd�� � ��
 ���� P�  �@��
IsSelected$
 True��. ��� $ Bd��8   � ����  �@�FocusVisualStyle Z� �� " ��.���  � ��8   ��  � ��8  ��  � �� �� " ��.R��� ���� *
Background+.��$� $
 True���� " ��.���  � �� �� " ��.R��  �� $
��Auto ��� $��0 ��� $��* �.+��� $��1��8��  �� $
 True���� $��2��$��0q�8�� ._��� $��SelectedContent���� " ��.���  � ��$ 13(���  � �� �� " ��.R�� $	��110�� �� $
��Auto ��� $��3 �.+��� �� $
 Back��$��1���� $ CP��$��Header��$��Center=�$��Center=�$��5q� P�  �@��
IsSelected$ False��. ��� $
 Back�� � ��
 ���� �� 8    � ��P�  �@J�IsMouseOver$
 true��. ��� 8   � ��P�  �@��
IsSelected$
 True��. ��� $
 Back��8   � ���� 8   � ���� " d�.R��� $ B_main��8��  $��1q�8�� ._��  �� �� $��15 �.+�F� $ Arrow��$��1��
�������$��Center=�$��Center=�"����        � 	=  	= � z     	 P�  �@J�IsMouseOver$
 true��. ��� $ B_main��8   � ��P�  �@d�	IsChecked$
 trueY�. ��� $ B_main��8   � ���� $ B_main��8   � ���� $ Arrow�� � y�$ Hidden=��� " ��.R��� $ PART_ContentHost��$|�False��#��z���� " ��.���  �@�UseLayoutRounding$
 True����  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 True����  � ��$
 Auto=���  � ��$
 Auto=���  � ��$
 true����  � ��$	 120����  � ��$ 25����  � ��$ 13(���  � ��8   ��  � �� �� " ��.R�� .+�d� $��ToggleButton��8�� $��2��$|�false��$ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite��$  False��#��z! #��z" #��z��$��5,3,5,3q�$��Center=�$
��Left=��� $# PART_EditableTextBox��8�� $
��Left=�$��Center=�$��5,3,5,3q�$
|�True�����	#FF3F3F3F
��� � �$y�Hidden=�#% z$ ��Z� � $��Popup��$��Bottom=�#��z& $
' True��$
 True��$
( True��$|�False��$
��Fade=�.��� $��DropDown��$
( True��#��z) #��z* .+��� $ DropDownBorder��8�� $��1q�8�� ._��� $��0q�$
( True��.���� $
 True��$+ 	Contained=� P�  �@��HasItems$ false��. ��� $ DropDownBorder�� � ��$ 95��P�  �@��
IsGrouping$
 true��. ���  � ��$ false��P� $, Popup�� �@�AllowsTransparency$
 true��. ��� $ DropDownBorder�� �@��CornerRadius$ 0���� $ DropDownBorder�� � ��$ 0,2,0,0q�P�  �@��
IsEditable$
 true��. ���  � ��$ false���� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=�- �� " ��.���  �@J�SnapsToDevicePixels$ False����  �@�UseLayoutRounding$ False����  � ��8   ��  �@�OverridesDefaultStyle$
 true����  � �� �� " ��.R��� $��Border��$
( true��._��� $��3q� P�  �@��IsHighlighted$
 true��. ��� $ Border��8   � ��P�  � {�$ false��. ���  � ��
 ���� �� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 True����  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��$ 10����  � ��$ 25����  �@J�	AllowDrop$
 true����  � ��8   ��  �@��
CaretBrush8  ��  � �� �� " ��.R��� $��Border��$��1q�8�� 8�� ._��� $. PART_ContentHost��$��Center=�$��3q� P�  �@J�IsMouseOver$
 true��. ��� $ Border��8   � ��P�  �@��IsSelectionActive$
 True��. ��� $ Border��8   � ���� $ Border��8   � ���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � |�$ false����  � �� �� " ��.R��� $ Border��8��  ._��� $ Symbol��$��18(�8�� 8�� $��Center=�$��Center=����� *	Content+ �� *TemplatedParent+ P�  � ��$
 True��. ��� $ Symbol��8   � ���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " ��.R��� 8��  �� " n�.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " n�.R��� $
 Back��8��   P�  �@J�IsMouseOver$
 true��. ��� $
 Back��8   � ���� " ��.R��  �� $��15���� $��0.00001* ��� $��15��.+��� $��3���� $��0��8��  $��ScrollBar.LineUpCommand��$	����]� $/ 
PART_Track��$��1��$
��true��0 �� 8�� $��ScrollBar.PageUpCommand��1 n� 8�� 
�������2 �� 8�� $��ScrollBar.PageDownCommand���� $��2��8�� $��ScrollBar.LineDownCommand��$	������ " ��.R��  �� $��15���� $��0.00001* ��� $��15��.+��� $��3���� $��0��8��  $��15��$��ScrollBar.LineLeftCommand��$	����]� $/ 
PART_Track��$��1��$��False��0 �� 8�� $��ScrollBar.PageLeftCommand��1 n� 8�� 
�������2 �� 8�� $ ��ScrollBar.PageRightCommand���� $��2��8�� $��15��$ ��ScrollBar.LineRightCommand��$	������ " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true��- P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 15����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 15����  � ��$
 Auto����  � ��8  �� " ��- P�  � {�$ false��. ���  � ��# � ��.���  � ��# �  �� " ��.R�� $
3 Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $!4 PART_ScrollContentPresenter��#5 z��$6 False��$7 False��#��z��#��z��$��0��#��z��$��0���� $8 PART_VerticalScrollBar��$9 VerticalScrollBar��$: Arrow��$��1��#< z; $= 0Q�$��0��#y�z> #@ z? A �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+�� $8 PART_HorizontalScrollBar��$9 HorizontalScrollBar��$: Arrow��$��0��#< zB $= 0Q�$C 
Horizontal=�$��1��#y�zD #@ zE A �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+