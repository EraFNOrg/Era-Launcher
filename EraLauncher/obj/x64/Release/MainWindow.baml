   M S B A M L   `   `   `  ���� F  BEraLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EraLauncherEraLauncher      EraLauncher.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:EraLauncher       � Title$  Fortnite Launcher��$	��610��$
��1280�� � WindowStyle$
 None=�$	��720��$
��1280��$
��1280��$	��720�����	#FF191919 � 
ResizeMode$ NoResize=�.��� -    �Name$ ApplicationBackground��$
��Left=�$	��720��$��	-24,0,0,0q�$	��Top=�$
��1304�����	#FF0E0C0C � ColumnDefinitions �� $
��354* ��� $	��57* ��� $
��331* ��� $	��30* ��� $��6* ��� $
��249* ��� $
��268* ��� $��9* �.+� � -     �Name$ PageContent��$��Frame��$��8��$��0,0,-1,0q��� -    ��Name$ 
UpperPanel��$��Center=�$��45��$	��Top=�$
��1309��$��8�����	#FF0C0C0E$��0,0,-5,0q��� $
��Left=�$��46��$��48,2,0,0q�$	��Top=�$��46������  �� ImageSource$ Misc/Images/EraLogo.png�� � Triggers :� 	 :� RoutedEvent$	 
MouseEnter��.[��� .���� .��W� 
 �� TargetProperty$
 Opacity� g� Duration$ 00:00:00.12D� W� From$ 1X�	 W� To$
 0.90X�:� $	 
MouseLeave��.[��� .���� .��W� $
 Opacity�$ 00:00:00.12D�$
 0.90X�$ 1X��� -    ��Name$ CloseButton��$
��Left=�$	��Top=�$��34��$��6��$��239.8,-1,0,0q� J� RenderTransformOrigin$ 	3.727,0.4&�$��31��$��10(�$��2����Z� ��Z� ��Z� ����  �� 
TargetType" ��.R���  �� CornerRadius$ 2��#��z��._��� $��Center=�$��Center=�.����  � 	Resources  �� 	UriSource   add �� DecodePixelWidth �� DecodePixelHeight  tile��%�   &	        &	 R     �� $8 2pack://application:,,,/Misc/Images/Icons/Close.png?�$	 200��$	 100���� $@ :pack://application:,,,/Misc/Images/Icons/Close_Hovered.png?�$	 200��$	 100������  �� 
TargetType" ��.���  �� Property � �� �� Value# [   �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �@�Cursor$
 Hand����  � ��# [ �� -   $ MinimizeButton��$
��Left=�$	��Top=�$��32��$��6��$��207.8,-1,0,0q�$ 	3.727,0.4&�$��31��$��Segoe UI Semibold)���Z� ��Z� ��Z� ���� " ��.R��� $ 2��#��z��._��� $��Center=�$��Center=�.����  ��%�   &	        &	 U     �� $; 5pack://application:,,,/Misc/Images/Icons/Minimize.png?�$	 200��$	 100���� $C =pack://application:,,,/Misc/Images/Icons/Minimize_Hovered.png?�$	 200��$	 100������ " ��.���  � ��# [   P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand����  � ��# [ �� -   $ MainPage_Btn��$
��Left=�$	��Top=�$��84��$��	99,22,0,0q�$ 	3.727,0.4&�$��23��
�������$��Segoe UI Semibold)� :� $	 
MouseEnter��.[��� .���� .��W� $
 Opacity�$ 00:00:00.10D�$	 0.5X�$
 0.75X�:� $	 
MouseLeave��.[��� .���� .��W� $
 Opacity�$ 00:00:00.10D�$
 0.75X�$	 0.5X�:� $	 	MouseDown��.[��� .���� .��W� $
 Opacity�$ 00:00:00.10D�$
 0.75X�$ 1X�.���  �� $��7* ��� $��3* �.+��� $
��PLAY��$��-17,-25,5.2,9.8q��� 
�������$��-31,-3,-14.6,-0.2q�$��2������ " ��.R��� $	��100��$��45��$ 4��#��z��._��� $��Center=�$��Center=����� " ��.���  �@J�Opacity$	 0.5Q���  � �� �	#00141414 P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand���� -   $ Changelog_Btn��$��Center=�$��Center=�$��64��$��189,22,101.4,675q�$ 	3.727,0.4&�$��23��
�������$��Segoe UI Semibold)����	#00141414.��� .+��� $
��NEWS��$��-17,-25,16.6,9.8q��� 
�������$��-32,-3,5.6,-0.2q� :� $	 	MouseDown��.[��� .���� .��W� $
 Opacity�$ 00:00:01D�$ 0X�$ 1X����� " ��.R��� $	��100��$��45��$ 4��#��z��._��� $��Center=�$��Center=����� " ��.���  �@J�Opacity$	 0.5Q���  � �� �	#FF141414 P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��:� $	 
MouseEnter��.[��� .���� .��W� $
 Opacity�$ 00:00:00.10D�$	 0.5X�$
 0.75X�:� $	 
MouseLeave��.[��� .���� .��W� $
 Opacity�$ 00:00:00.10D�$
 0.75X�$	 0.5X�� -   $ StartAnimGrid��$y�	Collapsed=�$��8��$��-64,-12,-1,0q�.+��� -	   $	 BGA�����	#FF0C0C0C$
��1369��$	��720��$
��Left=�$	��Top=�z�T� -
   BGATransform�� T� X$ 0Q� T� Y$ 0Q��� -   $ EraLOGOA��$��559,243,560.395,239q�$	��250��$	��250��$
��Left=�$	��Top=����� $ Misc/Images/EraLogo.png�� :� $	 FrameworkElement.Loaded��