var query_value;
var category;
var difficulty;
var show_atomic_only;
var categorylist = [
'All',
'Applied Science',
'Astronomy',
'Biology',
'Earth Science',
'Energy',
'General',
'Geology',
'Idiom',
'Physics'
]

function search(page_number, by_category) {
    	
    $('#search-string').html(query_value);
    if(query_value !== '' && /\S/.test(query_value)){
        $.ajax({
            type: "POST",
            url: "search.php",
            data: { query: query_value,
					category: category,
					difficulty: difficulty,
					atomic: show_atomic_only,
					page: page_number,
					by_category: by_category
			},
            cache: false,
			dataType: 'html',
            success: function(html){
					$('#browseByCategories').addClass('active').text("Back to Browse by Categories");

				if(/\S/.test(html)) {
				
				$('#results').html(html);
				$('.pagination').load("page.php", 
				{	query: query_value,
					category: category,
					difficulty: difficulty,
					atomic: show_atomic_only,
					page: page_number,
					by_category: by_category}, function() {
					
					$('#'+page_number+'-page').addClass('active');
					
					$(".paginate_click").on('click', function (e) {
					e.preventDefault(); 
							
					var clicked_id = $(this).attr("id").split("-"); //ID of clicked element, split() to get page number.
					var page_num = parseInt(clicked_id[0]); //clicked_id[0] holds the page number we need 
        
					$('.paginate_click').removeClass('active');
					clearTimeout($.data(this, 'timer'));
					//query_value = $('input#search').val();
					//category = $('#category option:selected').val();
				//	difficulty = $('#difficulty option:selected').val();
				//	show_atomic_only = $('#atomic input[type=radio]:checked').val();
					$(this).data('timer', setTimeout(search(page_num, by_category), 15));


					$('#'+clicked_id+'-page').addClass('active'); //add active class to currently clicked element        
					}); 
				});
				
					$(".tag_click").on('click', function(e){
					e.preventDefault(); 
					var clicked_query_value = $(this).html();
					$('input#search').val(clicked_query_value);
					query_value = $('input#search').val();
					category = $('#category option:selected').val();
					difficulty = $('#difficulty option:selected').val();
					show_atomic_only = $('#atomic input[type=radio]:checked').val();
					clearTimeout($.data(this, 'timer'));
					$(this).data('timer', setTimeout(search(1,0), 15));
					
					$('html,body').animate({
					scrollTop: $("body").offset().top},'fast');
					
					
					});			
				
				}
				else {$('#results').html('No results. Please try again.');}
				
				
            }
        });
    }return false;
}

$(document).ready(function(){
$('input#submit').on('click', function(e) {
    clearTimeout($.data(this, 'timer'));
    var search_string = $('input#search').val();
    
	
	
        $('#results').fadeIn();
    //    $('#resultpanel').fadeIn();
		$('.pagination').fadeIn();
		$('.category').fadeOut();
		$('.categories h3').addClass('active');

		//$('.category-link').fadeIn();
		query_value = $('input#search').val();if (search_string === '') {query_value='%';}
		category = $('#category option:selected').val();
		difficulty = $('#difficulty option:selected').val();
		show_atomic_only = $('#atomic input[type=radio]:checked').val();
        $(this).data('timer', setTimeout(search(1,0), 15));
   
});

$(document).keypress(function(e) {
    if(e.which==13){
		//alert('enter pressed')
	clearTimeout($.data(this, 'timer'));
    var search_string = $('input#search').val();
    
	
	
        $('#results').fadeIn();
    //    $('#resultpanel').fadeIn();
		$('.pagination').fadeIn();
		$('.category').fadeOut();
		$('.categories h3').addClass('active');

		//$('.category-link').fadeIn();
		query_value = $('input#search').val();if (search_string === '') {query_value='%';}
		category = $('#category option:selected').val();
		difficulty = $('#difficulty option:selected').val();
		show_atomic_only = $('#atomic input[type=radio]:checked').val();
        $(this).data('timer', setTimeout(search(1,0), 15));
	}
});


$('#advance-search').on('click', function(e){
	e.preventDefault();
	//$('#advance').toggle();
	$('#advance').animate({
					height: "toggle"}, 'fast');
					
					
})

$('.category').on('click', function(e){
	e.preventDefault();
    clearTimeout($.data(this, 'timer'));
	query_value = 'by_category';
	category = $(this).attr('data-category');
	//$('input#search').val('Category:'+categorylist[category]);
	//console.log(category);
	difficulty = $('#difficulty option:selected').val();
	show_atomic_only = $('#atomic input[type=radio]:checked').val();
	$(this).data('timer', setTimeout(search(1,1), 15));
	//$('.categories').fadeOut();
	$('#results').fadeIn();
	$('.pagination').fadeIn();
	$('.category').fadeOut();
	//$('.category-link').fadeIn();
	$('html,body').animate({
	scrollTop: $("body").offset().top},'fast');

})

$('#browseByCategories').on('click', function(e){
	e.preventDefault();
	if($(this).hasClass('active')){
		  $('#results').fadeOut(150);
      //  $('#resultpanel').fadeOut();
		$('.pagination').fadeOut(150, function(){		$('.category').fadeIn();
});
		$('#browseByCategories').removeClass('active').text("Browse by Categories");
		
	}
	
})

})