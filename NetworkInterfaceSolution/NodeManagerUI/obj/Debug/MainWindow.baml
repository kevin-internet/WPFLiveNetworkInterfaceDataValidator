   M S B A M L   `   `   `  ����H  DNodeManagerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:NodeManagerUINodeManagerUI  5   	       NodeManagerUI.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   'localclr-namespace:NodeManagerUI  5   	   -   5        $��windowsMain��5	   	     � Title$  Live Data Validator UI��5   	    � 
ResizeMode$ NoResize=�6(    � SizeToContent$ Width=�6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��4q�6"    �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5         ��Name$ btnAdd��5      $	��Add��6%   $��0,0,0,4q�6E   �� 5      -   5        $ 	btnRemove��5      $��Remove��6(   $��0,0,0,4q�6N   �� 5      -   5        $ 
btnOptions��5      $��Options��6)   $��0,0,0,4q�6Q   �� 5      -   5        $ btnSimulate��5      $��Turn Live Data On��6*   $��0,0,0,4q�6]   �� 5      -   5        $ btnSimulateOff��5      $��Turn Live Data Off��6-   $��0,0,0,4q�6d   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��1��6%      AutoGenerateColumns .     
IsReadOnly .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *NetworkInterfaceId+  5      $

 Name��6%    5   %   �� *NetworkInterfaceName+  5      $
 Description��6%    5    %   �� *NetworkInterfaceDescription+  5!      $

 Type��6%    5"   %   �� *NetworkInterfaceType+  5#      $
 Speed��6%    5$   %   �� *NetworkInterfaceSpeed+  5%      $
 Operational Status��6%    5&   %   �� *OperationalStatus+  5(      $
 Bytes Received��6%    5)      �� 5*       �� Path$ BytesReceived�6"    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6T    �� ValidationRules 5+      /   )NodeManagerUI.ValidationRuleBytesReceived  5,   "   ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6D      ValidatesOnTargetUpdated . 6b   5.      50        52      $
 
Bytes Sent��6%    53      �� 54      $ 	BytesSent�6"    . $ PropertyChanged=�6P    55      +   %NodeManagerUI.ValidationRuleBytesSent  56   "   $ UpdatedValue=�6@    . 6^   58      5:      5=      5>      5?      