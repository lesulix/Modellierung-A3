   M S B A M L   `   `   `  ����D  @SimpleCGA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SimpleCGA	SimpleCGA  5   	   N JSharpDX, Version=2.4.0.0, Culture=neutral, PublicKeyToken=627a3d6d1956f55a2&clr-namespace:SharpDX;assembly=SharpDXSharpDX 5   	   Z VHelixToolkit.SharpDX.Wpf, Version=2013.1.1.42964, Culture=neutral, PublicKeyToken=nulleHclr-namespace:HelixToolkit.SharpDX.Wpf;assembly=HelixToolkit.SharpDX.WpfHelixToolkit.SharpDX.Wpf 5   	       SimpleCGA.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:SimpleCGA     5   	   6sdx&clr-namespace:SharpDX;assembly=SharpDX     5   	   XhtxHclr-namespace:HelixToolkit.SharpDX.Wpf;assembly=HelixToolkit.SharpDX.Wpf     5   	   $	��600��5   #   $
��1200��60     � Title  6	   �� *	Student+ � 	Resources 5
      �� 5   
    �� Member$% htx:Techniques.RenderTechniques��6      KeyRenderTechniques  6E   u�5   
   LargeMargin  8q�6+   u�5   
   SmallMargin  2q�6+   �� 5   
   BoolToVisibilityConverter  6'   �� 5   
   Shape3DTemplate  .R�5      2  ,HelixToolkit.SharpDX.Wpf.MeshGeometryModel3D  .  (HelixToolkit.SharpDX.Wpf.GeometryModel3D   Geometry 6&   �� *
Geometry+&   HelixToolkit.SharpDX.Wpf.Model3D   	Transform 6D   �� *	Transform+6  0HelixToolkit.SharpDX.Wpf.MaterialGeometryModel3D   Material 6d   �� *
Material+5       J� InputBindings 5      �� 5   
   
 �� Key$ O��6    �� 	Modifiers$ Controlf�6   	 �� Command	 69   �� *	OpenCmd+�� 5   
   $ S��6   $ Controlf�6   	 69   �� *	SaveCmd+�� 5   
   $ P��6   $ Controlf�6   	 69   �� *ParseGrammarCmd+�� 5   
   $ F5��6   	 6!   �� *ParseGrammarCmd+.��5#      � 
 � RowDefinitions
 5$   
   �� 5%      $
��Auto �6   �� 5&      .+�5*   
   � $��1��6    � ColumnDefinitions 5+      �� 5,      $��2* �6#   �� 5-      $��3* �6#   .+�50      � $��0��6   $��0��6    
 51      �� 52      $
��Auto �6(   �� 53      $	��10* �6(   �� 54      $
��Auto �6(   �� 55      $
��Auto �6(   �� 56      $
��Auto �6(   .+�58      �� $��0��6   
�������
���  ��$��Stretch=�5;      $��Stretch=�5<      $��4q�5=       �� TextWrapping$
 Wrap=�5>       �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�5@       �� AcceptsReturn . ��5B      �� *Parser.ErrorText+y�5C      �� *Parser.HasError+  BoolToVisibilityConverter �� 	Converter# [ �� 5D      -   5         ��Name$ editor��5D   '   $��1��6   $��Stretch=�5E      $��Stretch=�5F      $��4q�5G      $
 Wrap=�5H      $
 Auto=�5I       .  �� 
AcceptsTab . ��5L      �� *Parser.ProductionCode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5M      $��2��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5N      ��   SmallMargin#��[ 6   ��6C   �� *ParseGrammarCmd+.��6g   Parse6n   �� 5P      #��[ 6   ��6C   �� *DefaultGrammarCmd+.��6i   	Default6r   �� 5Q      $��1��69   $��0��6F   #��[ 6V   ��6   �� *	OpenCmd+.��6|   Open6�   �� 5R      $��1��69   $��0��6F   #��[ 6V   ��6   �� *	SaveCmd+.��6|   Save6�   5S      5T      *  $HelixToolkit.SharpDX.Wpf.Viewport3DX  5V      -   5          Name$ view1��5X      $��0��5W      $��1��6      	TextBrush
 �   �&   CoordinateSystemLabelForeground
 �����   UseDefaultGestures .     Camera 5Y      �� *Camera+   Title 5Z      �� *Title+   SubTitle 5[      �� *
FileName+   IsShadowMappingEnabled 5^      �� *HasShadowMap+   RenderTechnique 5_      �� *RenderTechnique+ 5a      �� 5b      $ B��6!   $#	 htx:ViewportCommands.BackView��6)   �� 5c      $ F��6!   $$	 htx:ViewportCommands.FrontView��6)   �� 5d      $ U��6!   $"	 htx:ViewportCommands.TopView��6)   �� 5e      $ D��6!   $%	 htx:ViewportCommands.BottomView��6)   �� 5f      $ L��6!   $#	 htx:ViewportCommands.LeftView��6)   �� 5g      $ R��6!   $$	 htx:ViewportCommands.RightView��6)   �� 5h       �� Gesture$ 	Control+E��6!   $&	  htx:ViewportCommands.ZoomExtents��65   d� 5i        d� Gesture$  
RightClicka�6#   $!	 htx:ViewportCommands.Rotate��68   d� 5j      $  MiddleClicka�6#   $	 htx:ViewportCommands.Zoom��69   d� 5k      $  Shift+RightClicka�6#   $	 htx:ViewportCommands.Pan��6>   .@�5n      -  'HelixToolkit.SharpDX.Wpf.AmbientLight3D  &   HelixToolkit.SharpDX.Wpf.Light3D!   Color! 6%   �� *AmbientLightColor+1  +HelixToolkit.SharpDX.Wpf.DirectionalLight3D  5o      ! 6)   �� *DirectionalLight1Color+"   	Direction" 6R   �� *DirectionalLight1Direction+  5p      ! 6)   �� *DirectionalLight2Color+" 6R   �� *DirectionalLight2Direction+2	  ,HelixToolkit.SharpDX.Wpf.LineGeometryModel3D	  5s      #   IsThrowingShadow# .  $   	DepthBias$$ 0��6  (
  "HelixToolkit.SharpDX.Wpf.Element3D% 
  IsRendering% 6*   �� *
RenderAxes+ 6h   �� *Axes+ 6�   �� *AxesTransform+& 	  Color& 6�   �� *	AxesColor+' 	  	Thickness' 6�   �� *AxesThickness+( 	  
Smoothness( 6�   �� *AxesSmoothness+6  	  5t      # .  $$ 0��6  % 6*   �� *RenderGridXY+ 6h   �� *GridXY+ 6�   �� *AxesTransform+& 6�   �� *	GridColor+' 6�   �� *GridThickness+( 6�   �� *GridSmoothness+6  	  5u      # .  $$ 0��6  % 6*   �� *RenderGridXZ+ 6h   �� *GridXZ+ 6�   �� *AxesTransform+& 6�   �� *	GridColor+' 6�   �� *GridThickness+( 6�   �� *GridSmoothness+6    5v      -   5        )  Name$) plane��5v   *   # .   6R   �� *Plane+ 6m   �� *PlaneTransform+ 6�   �� *GrayMaterial+:  4HelixToolkit.SharpDX.Wpf.TransformableItems3DControl  5y      -  'HelixToolkit.SharpDX.Wpf.Items3DControl*   IsThrowingShadow* .   Shape3DTemplate#��[ 6J   ��6z   �� *Shapes++   	Transform+ 6�   �� *MainTransform+5{      5|      �� 5�   
   $��1��6   $
��Auto��6M   $��Right=�6Z   $	��Top=�6v   $
��Auto=�6�   $��Disabled=�6�   $��4q�6�   y�6%   �� *ControlsVisible+.��5�      �� $��0q�6   .+�5�      9� $��	Rendering��6   $��Right=�6/   $	��140��6K   $	��Top=�6W   
�������, 9� 
IsExpanded, . $��10q�6�   .��5�      � 
 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��0��6#   - �� Text$- - Select Techniqe -��61   . �� 
IsEditable. . / �� 
IsReadOnly/ . #��[ 6�   ��6L   ��   RenderTechniques0 �� Source#0 [ 1 �� SelectedItem1 6�   �� *RenderTechnique+6�   5�      5�      5�      5�      5�      5�      