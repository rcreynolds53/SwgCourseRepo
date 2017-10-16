$(document).ready(function () {
    loadVendingMachine();

})
var currentTotal = parseFloat($('#amountIn').val()).toFixed(2);
$('#add-dollar-button').click(function () {
    if (isNaN(currentTotal)) {
        currentTotal = 0.00;
    }
    currentTotal = (parseFloat(currentTotal) + parseFloat(1.00)).toFixed(2);
    $('#amountIn').val(currentTotal);
});
$('#add-quarter-button').click(function () {
    if (isNaN(currentTotal)) {
        currentTotal = 0.00;
    }
    currentTotal = (parseFloat(currentTotal) + parseFloat(0.25)).toFixed(2);
    $('#amountIn').val(currentTotal);
});
$('#add-dime-button').click(function () {
    if (isNaN(currentTotal)) {
        currentTotal = 0.00;
    }
    currentTotal = (parseFloat(currentTotal) + parseFloat(0.10)).toFixed(2);
    $('#amountIn').val(currentTotal);
});
$('#add-nickel-button').click(function () {
    if (isNaN(currentTotal)) {
        currentTotal = 0.00;
    }
    currentTotal = (parseFloat(currentTotal) + parseFloat(0.05)).toFixed(2);
    $('#amountIn').val(currentTotal);
});
$('#itemsDiv').on('click', '.item', function () {
    var itemToBuyId = $(this).data('id');
    var itemToBuyName = $(this).data('formatted');
    $('#itemID').val(itemToBuyId);
    $('#itemName').val(itemToBuyName);

});
$('#return-change-button').on('click', function () {
    var moneyIn = parseFloat($('#amountIn').val()).toFixed(2);
    var quarters;
    var dimes;
    var nickels;
  while (moneyIn !=0)
  {
      
          quarters = moneyIn / .25;
           quarters = Math.floor(quarters);
          moneyIn = moneyIn % .25;
          dimes = moneyIn / .10;
          dimes = Math.floor(dimes);
          moneyIn = moneyIn % .10;
          nickels = moneyIn / .05;
          nickels = Math.floor(nickels);
          moneyIn = moneyIn % .05;
          $('#changeBack').val("Quarters: "+ quarters +", Dimes: "+ dimes + ", Nickels: "+ nickels);
          $('#amountIn').val("0.00");
          $('#itemID').val("");
          $('#itemName').val("");
          $('#messages').val("");
          currentTotal = 0;
          return;
      }

    $('#messages').val("");
    $('#itemsDiv').empty();
    $('#amountIn').val("0.00");
    $('#itemID').val("");
    $('#itemName').val("");
    $('#changeBack').val("");
    loadVendingMachine();

});
$('#make-purchase-button').on('click', function () {
    $('#messages').val("");
    $('#changeBack').val("");
    var itemId = $('#itemID').val();
    var amount = $('#amountIn').val();
    var url = 'http://localhost:8080/money/' + amount + '/item/' + itemId;
    
    $.ajax({
        type: 'GET',
        url: url,
        success: function (change) { 
                $('#changeBack').val("Quarters: "+ change.quarters +", Dimes: "+ change.dimes + ", Nickels: "+ change.nickels);
           //var totalChange = ((change.quarters * .25) + (change.dimes * .1) + (change.nickels *.05));
           //var itemPrice = amount-totalChange;
            currentTotal = 0;
            $('#messages').val("THANK YOU!");
            $('#itemsDiv').empty();
            $('#amountIn').val(0.00);
            $('#itemID').val("");
            $('#itemName').val("");            
            loadVendingMachine();
            
           
        },
        error: function (jpXHR, textStatus, errorThrown) {
            if(jpXHR.responseJSON.message == "No message available")
            {
                $('#messages').val("Error: No item selected.");
            }
            else
            {
            $('#messages').val(jpXHR.responseJSON.message);
            }
           
        }
    });
           
});
function loadVendingMachine() {
    $.ajax({

        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (itemsArray) {
            $.each(itemsArray, function (index, item) {
                var itemsDiv = $('#itemsDiv');

                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var card = '<div class="col-xs-3 item" data-id = "' + id + '" data-formatted= "' + name + '">'
                card += '<p style = text-align:left>' + id + '</p>';
                card += '<p style = "text-align: center"><strong>' + name + '</strong></p>';
                card += '<p style="text-align:center">$' + price.toFixed(2) + '</p><br>';
                card += '<p style="text-align: center">Quantity Left: ' + quantity + '</p>';
                card += '</div>';

                itemsDiv.append(card);

            })

        },

        error: function () {

        }
    });
}