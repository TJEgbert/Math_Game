   M S B A M L   `   `   `  ����D  @math_game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:math_game	math_game  5   	       math_game.gameWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:math_game     5   	   -   5          �Name$  wnd_gameWindow��5   	    � Title$ Game Window��5   	   $	��699��6   $	��789��6*    � 
ResizeMode$ NoResize=�6e   ��5	      �� 5
   
    �� ImageSource$$ /Images/additionBackground.png��6   .��5      �  � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $
��782* �6   .+�5   
   �� $��160,10,172,99q�6   ���	#7F0A25FF$��1��6?   �� 5   
   -   5         ��Name$ lbl_gameWindow��5      $��
10 + 10 = ��6(   $��Center=�6=   $��	0,113,0,0q�6Z   $	��Top=�6m   $	��118��6�   $	��392��6�   $��90(�6�   $��Comic Sans MS)�6�   ���	#FFFFD302 J� RenderTransformOrigin$ 
0.271,0.51&�6�   $��1��6  �� 5   
   -   5         ��Name$ cmd_gameStart��5      $��
Start Game��6(   $��219,423,238,119q�6=   ���	#FFDDDDDD
���   �$��Comic Sans MS)�6�   $��45(�6�   $��1��6�   �� 5   
   -   5        $ lbl_answerStatus��5      $��	 Correct!��6*   $
��Left=�6>   $��290,264,0,0q�6Y   $	��Top=�6n   $	��176��6�   $��66��6�   $��Comic Sans MS)�6�   $��35(�6�   ���	#FFFFD302$��1��6�   �� 5   
   -   5        	 ��Name$	 
txt_answer��5      $
��Left=�6&   $��277,342,0,0q�6A   
 �� TextWrapping$

 Wrap=�6V   $	��Top=�6j   $	��189��6�   $��56��6�   $��30(�6�    �� 	MaxLength$ 3��6�   $��1��6�   �� 5   
   -   5        $ 
cmd_submit��5      $��Submit��6%   $
��Left=�66   $��291,433,0,0q�6Q   $	��Top=�6f   $��93��6�   $	��188��6�   $��Comic Sans MS)�6�   $��35(�6�   ���	#FFDDDDDD
���   �$��1��6  $
��Bold"�6  $y�Hidden=�6$  �� 5   
   -   5        $ lbl_errorInput��5      $��this is the error��6(   $
��Left=�6D   $��301,226,0,0q�6_   $	��Top=�6t   
���  ��$��20(�6�   $��1��6�   $��Comic Sans MS)�6�   �� 5   
   -   5        $ 	lbl_timer��5      $��00��6#   $
��Left=�60   $��
498,28,0,0q�6K   $	��Top=�6_   $��85��6w   $��80��6�   $��50(�6�   $��Comic Sans MS)�6�   ���	#FFFFD302$��1��6�   5      5      