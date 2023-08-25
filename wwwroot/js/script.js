let mynav = document.getElementsByTagName('nav')[0];
let links = document.getElementsByClassName('noscroll');
let heading = document.getElementById('foodDash');
console.log(mynav.offsetHeight);
window.onscroll = function () {
    console.log(document.documentElement.scrollTop);
    if(document.documentElement.scrollTop >= mynav.offsetHeight)
    {
        mynav.style.backgroundColor='white';
        mynav.style.position='fixed';
        for(let i = 0;i<links.length;i++)
        {
            links[i].style.color='rgb(235, 140, 16)';
        }
        heading.style.color='rgb(235, 140, 16)';
    }
    else
    {
        mynav.style.backgroundColor='transparent';
        mynav.style.position = 'absolute';
        for(let i = 0;i<links.length;i++)
        {
            links[i].style.color='white';
        }
        heading.style.color='white';
    }
}

function reveal()
{
    var reveals=document.getElementsByClassName('reveal');

    for(let i = 0;i<reveals.length;i++)
    {
        let winHeight = window.innerHeight;
        let elemTop = reveals[i].getBoundingClientRect().top;
        let elemVisible = 60;
        if (elemTop < winHeight - elemVisible) 
        {
            reveals[i].classList.add("active");
        } 
        else 
        {
            reveals[i].classList.remove("active");
        }
    }
}

window.addEventListener('scroll',reveal);