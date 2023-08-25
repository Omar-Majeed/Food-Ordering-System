function fastFood()
{
    activeButtons = document.getElementsByClassName('active');
    activeButtons = activeButtons.item(0);
    activeButtons.classList.toggle('active');

    fast = document.getElementById('fast');
    fast.classList.toggle('active');

    alreadyActivesImages= document.getElementsByClassName('activeImages');
    alreadyActivesImages = alreadyActivesImages.item(0);
    alreadyActivesImages.classList.toggle('activeImages');

    desiFoodImages = document.getElementById('fast_food');
    desiFoodImages.classList.toggle('activeImages');
}

function desiFood()
{
    activeButtons = document.getElementsByClassName('active');
    activeButtons = activeButtons.item(0);
    activeButtons.classList.toggle('active');

    fast = document.getElementById('desi');
    fast.classList.toggle('active');

    alreadyActivesImages= document.getElementsByClassName('activeImages');
    alreadyActivesImages = alreadyActivesImages.item(0);
    alreadyActivesImages.classList.toggle('activeImages');

    desiFoodImages = document.getElementById('desi_food');
    desiFoodImages.classList.toggle('activeImages');
}

function desserts()
{
    activeButtons = document.getElementsByClassName('active');
    activeButtons = activeButtons.item(0);
    activeButtons.classList.toggle('active');

    fast = document.getElementById('dessert');
    fast.classList.toggle('active');

    alreadyActivesImages= document.getElementsByClassName('activeImages');
    alreadyActivesImages = alreadyActivesImages.item(0);
    alreadyActivesImages.classList.toggle('activeImages');

    desiFoodImages = document.getElementById('dessert_food');
    desiFoodImages.classList.toggle('activeImages');
}

let allowUnload = false;
let data = {}

$(document).ready(function(){
    $.ajax({
        url: '/addItem',
        type:"GET",
        success: function(response)
        {
            for(let dish in response)
            {
                for(let i = 0;i<response[dish]['count'];i++)
                {
                     var cartItem = '<div class="cart-item">' +
                            '<h4 class="item-name inline";">' + dish + '</h4>' + ': ' +
                            '<h4 class="inline">' + response[dish]['price'] + '</h4>' +
                            '<button class="remove-item">X</button>' +
                           '</div>';
                            $('.cart-item-list').append(cartItem);
                }
            }
            if(response)
            {
                data = response;
            }
        }
    })
})

$(document).ready(function() {
      // Add item to cart
      $(document).on('click', '.add-to-cart', function(event) {
        food = event.target;
        var itemName = food.innerHTML;
        
        //10
        if(data.hasOwnProperty(food.innerHTML))
        {
            let item = data[itemName];
            //will increase count of items
            item.count = item.count + 1;
            data[itemName] = item;
            count = item.count;
        }
        else
        {
            //if item doesnt exist it creates and gives count 1
            img = $(event.target).parent().prev()[0];
            let item = {'price': food.getAttribute('value'), 'count': 1, 'url':$(img).attr('src')}
            data[food.innerHTML]=item

        }
        var cartItem = '<div class="cart-item">' + 
                            '<h4 class="item-name inline";">' + food.innerHTML + '</h4>' + ': ' +
                            '<h4 class="inline">' + food.getAttribute('value') + '</h4>' +
                            '<button class="remove-item">X</button>' + 
                           '</div>';

        $('.cart-item-list').append(cartItem);
        if (!$('#cart').hasClass('show')) {
          $('#cart').addClass('show');
        }
      });
  
      // Remove item from cart
    $(document).on('click', '.remove-item', function() {
      console.log('remove')
      dishName = $(this).prev().prev().text();
        let dish = data[dishName]
        dish["count"] -= 1
        data[dishName] = dish

        if(dish["count"] == 0)
        {
            delete data[dishName];
        }
      
      $.ajax({
        url:'/removeItem',
        type:'POST',
        data: JSON.stringify(dishName),

      });
      $(this).closest('.cart-item').remove();

    });

    // Hide cart when the close button is clicked
    $('#close-cart').click(function() {
      $('#cart').removeClass('show');
    });

    $('#show_menu_button').click(function(){
      
            $('#cart').toggleClass('show');
    })

    $('#submit-cart').click(function()
    {
        data = JSON.stringify(data);

        $.ajax({
            url: '/addItem',
            type: 'POST',
            data:data,

            success: function(response)
            {
                window.location.href = "http://127.0.0.1:5000/checkout";
            }
        })
    })
  });


  $(document).ready(function() 
  {
      $.ajax({
      type:'GET',
      url:'/getDishDetails',
      success: function(response)
       {
          console.log(response);
          for(let i of response)
          {
            if(i['type'] == 'Fast')
            {
              obj = document.getElementById('fast_food');
            }

            else if(i['type'] == 'Desi')
            {
              obj = document.getElementById('desi_food');
            }
            else if(i['type'] == 'Desert')
            {
              obj = document.getElementById('dessert_food');
            }
              
            let dish = document.createElement("div");
            $(dish).addClass('food_info_container');

            dish.innerHTML = "<div class='img_wrap food_image_container'><img src=" + i.imageurl + " alt=" + i.dishName + " class='food_image'><div class='add-to-cart'><p class='img_description' value="+i.price+">" + i.dishName + "</p></div></div><figcaption>"
            + i.dishName + "<br>Rs." + i.price + "</figcaption>";

            obj.append(dish);
          }
      }
    });
  });
