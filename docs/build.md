# ���

ʹ��nuget�ű�
* vs2019 �򿪹���
* ѡ��release any cpu
* ����Nuget/create-packages.cmd


ʹ����������uwp��ʱ����
dotnet pack MultiLanguageForXAML.WPF -o ../LocalNuget/Packages -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
dotnet pack MultiLanguageForXAML.UWP -o ../LocalNuget/Packages -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg