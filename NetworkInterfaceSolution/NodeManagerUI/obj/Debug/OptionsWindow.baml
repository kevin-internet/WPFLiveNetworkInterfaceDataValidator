   M S B A M L   `   `   `  ����H  DNodeManagerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:NodeManagerUINodeManagerUI  5   	   !    NodeManagerUI.OptionsWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   'localclr-namespace:NodeManagerUI  5   	     � Title$!  OPTIONS - SELECT ROWS FIRST��5	   	    � SizeToContent$ WidthAndHeight=�6-    � 
ResizeMode$ NoResize=�6L   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ txtBlockTitle��5   5   $��0��6   $��3��6!   $��MAXIMUM THRESHOLD VALUES��5      $��8q�64    �� TextAlignment$ Center=�6?   $
��Bold"�5      �� 5      -   5         ��Name$ label��5   1   $��1��6   $��0��6!   $��BYTES RECEIVED��6@   �� 5      -   5         ��Name$ txtBytesReceived��5   3   $��1��6   $��1��6#   $��4q�6M   $��50��5      �� 5       -   5        $ label2��5    1   $��2��6   $��0��6!   $��
BYTES SENT��6A   �� 5!      -   5        $ txtBytesSent��5!   3   $��2��6   $��1��6#   $��4q�6I   $��50��5"      �� 57   
   $��5��6   $��2��6"   	 �� Orientation$	 
Horizontal=�66   $��Right=�6O   .+�58   
   �� -   5        
 ��Name$
 button��58      $��OK��6!   $��Right=�6.   $��0q�6J   6U   �� 59   
   -   5        $
 button1��59      $��Cancel��6"   $��Right=�63   $��0q�6O   6Z   �� 5:   
   -   5        $
 button2��5:      $��Apply��6"   $��Right=�62   $��0q�6N   6Y   5;      5=      5>      