   M S B A M L   `   `   `  ���� F  BEraLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EraLauncherEraLauncher      EraLauncher.Home   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:EraLauncher     -     N�Name$  HomePage�� N� Title$ Fortnite Launcher��$	��720��$
��1280��$	��720��$
��1280��$
��1280��$	��720�� N� 
Background �	#FF191919.��� -    �Name$ GridBG��$
��Left=�$	��720��$��	-24,0,0,0q�$	��Top=�$
��1304�����	#FF0E0C0C � ColumnDefinitions �� $
��426* ��� $
��346* ��� $��6* ��� $
��249* ��� $
��277* �.+��� -    ��Name$ BackgroundImage��$
��Left=�$	��720��$	��Top=�$
��1316��$��5��$��0,-72,-12,0q�]� -    ]�Name$" VersionInformationBackground��$
��Left=�$	��490����.  $	��Top=�$	��394��
���   � J� Opacity$	 0.7Q�$��0,-7,0,0q��� -    ��Name$ GameName��$��Fortnite��$
��Left=�$��	72,60,0,0q�$	��Top=����	#FFDDDDDD$��28(�$
��Bold"�$��53��$	��150��	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� �� 
 �� AngleY$
 -0.689Q��� T�  T� Y$ -0.788Q�]� -   $ LowerVersionsPanel��$��Center=�$	��391����.  $��-55,434,-31,-105q�$	��Top=�$
��1390�����	#FF111010$��5���� -   $ GameVersion��$��Select Game Version.��$
��Left=�$��	73,94,0,0q�$	��Top=�
�������$	 0.8Q�$��20(�$��43��$	��235��$��SemiBold"��� -    ��Name$ LaunchButton��$��Launch��$��48,299,46.4,329q�
�������$��19(�$��Medium"�����  �� 
TargetType" ��.R��� $	��270��$��65�� �� CornerRadius$ 2��#��z��._��� $��Center=�$��Center=�����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF8EBA8A��  �@�Cursor$
 Hand�� �� Triggers :�  :� RoutedEvent$ UIElement.MouseEnter��.[��� .���� .����  �� TargetProperty$ Background.Color� g� Duration$ 00:00:00.15D� �� From$ 	#FF8EBA8AX�	 �� To$ 	#FF9ACA96X�:� $ UIElement.MouseLeave��.[��� .���� .���� $ Background.Color�$ 00:00:00.15D�$ 	#FF9ACA96X�$ 	#FF8EBA8AX��� -	    ��Name$ LauncherInformation��$���Fortnite includes Battle Royale, the completely free 100-player PvP mode. One giant map. A Battle Bus. Last one standing wins. ��$
��Left=�$��
79,133,0,0q�$	��Top=�
�������$	��132��$	��261��$
��Wrap=�$
 0.65Q�$��11(��� -
    ��Name$ VersionsList��$	��271��$��5��$��24,0,0,0q�$��Bottom=�$��Right=�$
��1284����. $��Hidden=�$��Hidden=�$��0,0,-6,0q���Z� ��Z� ��Z� ���� *	Versionsa+���� " ��.���  � �� �� " ��.R��� ���� .R�A�  A� Columns$ 8�� A� Rows$ 1��$��Stretch=�$
��1280��$	��174������ .R�� .+��� $ VersionSplash������ *
splashpath+�� $ GradientVersion��$$��Misc/Images/SplashGradient.png��$ 60Q��� $ VersionNameTextBlock��
������� �� TextAlignment$ Center=�$��Medium"�$
��Wrap=�$��11(�$��	0,150,0,0q����� *Id+��  �� Orientation$ Vertical=�$	��200��.+��� $ VersionAddButton��-   
������ $	��200��$	��200��$��Center=�$��Center=�$��100,0,100,0q�$��3q�$ 1Q����� *Id+���� " ��.R�� .+��� $	��150��$��173.5��$��0, -25.85,0, 0q�$ 0��
������ 
�������$��2q�$ 0Q����� " �� :� $ UIElement.MouseEnter��.[��� .���� .��W� $ Opacity�$ 00:00:00.20D� W� From$ 0X�	 W� To$	 0.5X�:� $ UIElement.MouseLeave��.[��� .���� .��W� $ Opacity�$ 00:00:00.20D�$	 0.5X�$ 0X�._��� $��Center=�$��Center=��� $��1q�$
��Left=�$��3��$��
79,390,0,0q�$	��Top=�$	��272��
�������$	 0.2Q�� $
��Left=�$	��730��$��Bottom=�$
��1304��$��5��$��	0,-7,0,-3q� �� $	��45* ��� $��1259* �  � RowDefinitions  �� $��7* ��� $	��66* ��� -   $ AddVersionButton��$
��Left=�$��202,450,0,0q�$	��Top=�$��25��$��25��$	��Top=�$
��Left=�$��28(�
�������.���� $��+��$��14(�$��0,-3,0,0q����� " ��.R��� $ 2��#��z��._��� $��Center=�$��Center=����� " ��.���  � �� �	#FF1F2025��  �@�Cursor$
 Hand�� :� $ 
MouseEnter��.[��� .���� .���� $ Background.Color�$ 00:00:00.15D�$ 	#FF1F2025X�$ 	#FF252731X�:� $ 
MouseLeave��.[��� .���� .���� $ Background.Color�$ 00:00:00.15D�$ 	#FF252731X�$ 	#FF1F2025X��� -   $�� ��$
��Left=�$��212,405,0,0q�$	��Top=�$��18��$��13��$	 0.985,0.636&���Z� ���� " ��.R��� $ 2��#��z��._��� $��Center=�$��Center=����� ! �� ImageSource$!! Misc/Images/DiscordIcon.png������ " ��.���  �@�Cursor$
 Hand�� :� $ UIElement.MouseEnter��.[��� .���� .��W� $ Opacity�$ 00:00:00.15D�$ 1X�$
 0.75X�:� $ UIElement.MouseLeave��.[��� .���� .��W� $ Opacity�$ 00:00:00.15D�$
 0.75X�$ 1X��� $��GAME VERSIONS��$
��Left=�$��
53,445,0,0q�$	��Top=�
�������$��18(�$
 0.75Q��� $��1q�$
��Left=�$��3��$��239,461,0,0q�$	��Top=�$
��1062��
�������$	 0.4Q�$��5���� -   $ RemoveBuild��$��311,299,76.4,329q�
�������$��15(�$��Medium"�$	 0.5,0.5&���Z� .���� $��13��$��13��$��	0,0,210,0q����� $"! Misc/Images/nav-settings.png��z�V� .~��� " �� ScaleX$" -1Q��� �� T� ���� " ��.R��� $	��252��$��65��$ 2��#��z��._��� $��Center=�$��Center=����� " ��.���  � �� �	#FF74A26F��  �@�Cursor$
 Hand�� :� $ UIElement.MouseEnter��.[��� .���� .���� $ Background.Color�$ 00:00:00.15D�$ 	#FF74A26FX�$ 	#FF6C9C67X�:� $ UIElement.MouseLeave��.[��� .���� .���� $ Background.Color�$ 00:00:00.15D�$ 	#FF6C9C67X�$ 	#FF74A26FX� � -   #  �Name$$# AdditionalSettingsFrameContent��$��Frame��$
��Left=�$	��Top=�$��5��$	��720��$
��1304��$y�Hidden=�