$(function(){
	var indicators = ''
	for(var i = 0 ; i< $('#slider-imgs .item').length; i++)
	{
		indicators += '<li data-target="#carousel-example-generic" data-slide-to="'+i+'"></li>';
	}
	$('#slider-control').append(indicators).find('li').first().addClass('active')
})
