<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Control Language="C#" CompilationMode="Always" %>
<SharePoint:RenderingTemplate ID="DG.EmbratelintranetRendering" runat="server">
    <Template>
        <table>
            <script type="text/javascript">
                function validaCNPJ(source, arguments) {
                    arguments.IsValid = false;
                    var cnpj = arguments.Value;

                    cnpj = cnpj.replace('/', '');
                    cnpj = cnpj.replace('.', '');
                    cnpj = cnpj.replace('.', '');
                    cnpj = cnpj.replace('-', '');

                    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
                    digitos_iguais = 1;

                    if (cnpj.length < 14 && cnpj.length < 15) {
                        arguments.IsValid = false;
                    }
                    for (i = 0; i < cnpj.length - 1; i++) {
                        if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
                            digitos_iguais = 0;
                            break;
                        }
                    }

                    if (!digitos_iguais) {
                        tamanho = cnpj.length - 2
                        numeros = cnpj.substring(0, tamanho);
                        digitos = cnpj.substring(tamanho);
                        soma = 0;
                        pos = tamanho - 7;

                        for (i = tamanho; i >= 1; i--) {
                            soma += numeros.charAt(tamanho - i) * pos--;
                            if (pos < 2) {
                                pos = 9;
                            }
                        }
                        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                        if (resultado != digitos.charAt(0)) {
                            arguments.IsValid = false;
                        }
                        tamanho = tamanho + 1;
                        numeros = cnpj.substring(0, tamanho);
                        soma = 0;
                        pos = tamanho - 7;
                        for (i = tamanho; i >= 1; i--) {
                            soma += numeros.charAt(tamanho - i) * pos--;
                            if (pos < 2) {
                                pos = 9;
                            }
                        }
                        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                        if (resultado != digitos.charAt(1)) {
                            arguments.IsValid = false;
                        }
                        arguments.IsValid = true;
                    } else {
                        arguments.IsValid = false;
                    }
                }

                function validaCPF(source, arguments) {
                    arguments.IsValid = false;
                    var cpf = arguments.Value;

                    cpf = cpf.replace('/', '');
                    cpf = cpf.replace('.', '');
                    cpf = cpf.replace('.', '');
                    cpf = cpf.replace('-', '');

                    while (cpf.length < 11)
                        cpf = "0" + cpf;

                    var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
                    var a = [];
                    var b = new Number;
                    var c = 11;

                    for (i = 0; i < 11; i++) {
                        a[i] = cpf.charAt(i);

                        if (i < 9)
                            b += (a[i] * --c);
                    }

                    if ((x = b % 11) < 2) {
                        a[9] = 0;
                    } else {
                        a[9] = 11 - x;
                    }

                    b = 0;
                    c = 11;

                    for (y = 0; y < 10; y++)
                        b += (a[y] * c--);

                    if ((x = b % 11) < 2) {
                        a[10] = 0;
                    } else {
                        a[10] = 11 - x;
                    }

                    if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg))
                        arguments.IsValid = false;
                    else
                        arguments.IsValid = true;

                }
                //                $('input[mask]').each(
                //                    function (i, l) {
                //                        if ($(this).attr('mask').length > 0)
                //                            $(this).mask($(this).attr('mask'));
                //                    }
                //                );
            </script>
            <tr>
                <td>
                    <asp:TextBox ID="txtText" name="txtTexto" runat="server" mask=""></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="customValidator" runat="server" ErrorMessage="CustomValidatorError"
                        ControlToValidate="txtText" SetFocusOnError="True" ValidateEmptyText="false"
                        Visible="false" Display="Dynamic"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="regexValidator" runat="server" ErrorMessage="RegularExpressionValidatorError"
                        ControlToValidate="txtText" SetFocusOnError="True" ValidateEmptyText="false"
                        Visible="false" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="requiredValidator" runat="server" ErrorMessage="RequiredFieldValidatorError"
                        ControlToValidate="txtText" SetFocusOnError="True" ValidateEmptyText="True" Visible="false"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </Template>
</SharePoint:RenderingTemplate>
