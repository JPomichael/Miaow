var iPowTour=null;
var tripData=[];//数据结构[{DayID:1,TName:"三日游",Destination:"目的地",Sight:[{SName:锦绣中华,SID:10003,Ticket:￥250,IMG:"",Latitude:32,Longitude:12}],Hotel:[{HName:酒店名称,HID:10003,Star:5,Address:横岗,HPrice:￥1250}],Traffic:[{Model:公交}],DTotal:￥2345,UserName:"",UserID:1}]
var cirHotelInfo = [];//周边酒店信息
var iPowApi = "http://192.168.1.65:199/";
//行程定义类
//数据结构[{ID:1,DayID:1,TName:三日游,Sight:[{SName:锦绣中华,Ticket:￥250,IMG:"",Latitude:32,Longitude:12}],Hotel:[{HName:酒店名称,Star:5,Address:横岗,HPrice:￥1250,Latitude:32,Longitude:12}],Traffic:[{Model:公交}],DTotal:￥2345}]
//周边酒店信息：[{HotelID:1000,HName:酒店名称,Star:星级,Address:酒店地址,HPrice:价格,Latitude:32,Longitude:12}]
var tripListData;
var globalTripData;
function DrawTravel(element,parameters)
{
	this.element = null;
	this.parameters = parameters;
	this.travelElem = $("#hodometerContainer");
	this.isScroll = false;
	this.filters = {Const:[],DayNum:[],Live:[]};
	this.resultSize = 5;
	this.exituser = "Exist";
	this.toolHeight = 146;
} 
DrawTravel.prototype={
	init:function(obj){
		try
		{
			var tElem = this.travelElem;
			this.element = obj;
			var tempThis = this;
			var _travelPosition = getAllPosition(tElem);
			var _scrTop = _travelPosition.scrTop;
			if (_scrTop<140)
			{
				_scrTop = 10;
			}
			else
			{
				_scrTop=parseInt(_scrTop-136);
					
			}
			tElem.animate({top: _scrTop},10).slideDown("fast",function(){
				var _sightobj = obj.prev();
				var _sightname = $(_sightobj).attr("title"); //景区名称
				var _ticket = $(_sightobj).find("font.fontBlue2").text();  //景区门票
				var _address = $(_sightobj).find("dl dd").text();  //景区门票
				var _sightimg = $(_sightobj).find("span.img1 img").attr("src");  //景区图片
				var _sightother = $(_sightobj).attr("rel").split("|"); //景区ID、经度、维度
				var _sightid = _sightother[0];
				var _sightHtml = '<a href="javascript:;"><img src="'+_sightimg+'"/><em>'+_sightname+'</em><h3>￥'+_ticket+'</h3></a>';
				var _daynum = parseInt(tripData.length+1);
				var _dayamount = 0; //当天的消费
				$("#TravelArea").text($("#txtKeyword").val());
				_dayamount = parseInt(_dayamount)+parseInt(_ticket);
				//景区信息
				var sightJson = [{
					SName:_sightname,
					SID:_sightid,
					Ticket:_ticket,
					IMG:_sightimg,
					Address:_address,
					Latitude:_sightother[1],
					Longitude:_sightother[2]
				}];
				var tempTripData = {
					DayID:_daynum,
					TName:"",
					Sight:sightJson,
					Hotel:[],
					Traffic:[],
					DTotal:_dayamount,
					Destination:$("#txtKeyword").val()
					
				}
				if (tripData.length>0)
				{
					if (!tempThis.isExist(tempTripData.Sight[0]))
					{
						//弹出层表单数据
						var _tempHtml = '<div class="TB_Form"><span><label>选择行程：</label>';
						_tempHtml += '<select name="selTravel" id="selTravel" class="selStyle">';
						for (var j=1;j<=_daynum;j++)
						{
							if (j==_daynum)
								_tempHtml += '	<option value="'+j+'" selected="selected">第'+j+'天</option>';
							else
								_tempHtml += '	<option value="'+j+'">第'+j+'天</option>';
						}
						_tempHtml += '</select><a href="javascript:;" class="btnSubmit" id="btnSetPlan"></a></span>';
						_tempHtml += '</div>';
						//弹出图层
						$(obj).TBwin({
							width:300,
							height:100,
							title:"行程安排",
							datahtml:_tempHtml,
							datatype:"html",
							isBG:false,
							callback:function(){
								$("#btnSetPlan").click(function(){
									_sightHtml = '<a href="javascript:;" id="tripSight0"><img src="'+_sightimg+'"/><em>'+_sightname+'</em><h4></h4><h3>￥'+_ticket+'</h3></a>';
									tempThis.toPlan($("#selTravel option:selected").attr("value"),_sightHtml,tempTripData)
								}
							)}
						});
					}
					else
					{
						alert("已经存在此景区:)");
					}
				}
				else
				{
					_sightHtml = '<a href="javascript:;" id="tripSight00"><img src="'+_sightimg+'"/><em>'+_sightname+'</em><h4></h4><h3>￥'+_ticket+'</h3></a>';
					$("#hodometerSightBot").append('<span>'+_sightHtml+'</span>');
					//删除景区
					$("#tripSight00 h4").click(function(){
						tempThis.deleteSight(tempTripData.Sight[0],1);
					});
					$("#tripSight00").hover(
						function () {
							$(this).find("h4").show();
						},
						function () {
							$(this).find("h4").hide();
						}
					); 
					$("#dayAmount").text("￥"+tempTripData.DTotal);
					tripData.push(tempTripData);
					//加载酒店信息
					tempThis.loadHotelInfo(tempTripData.Sight[0].SID,1,false);
				}
				if(!tempThis.isScroll)
					tempThis.wscroll();  //滚动事件
			});
		}
		catch(e){}
		
	},
	wscroll:function(){   //滚动事件
		var tElem = this.travelElem;
		if (tElem.is(":visible"))
		{
			var main = this;
			$(window).scroll(function(){
				main.isScroll = true;
				main.resetPosition(tElem);
			});
		}
	},
	hide:function(){    //隐藏行程表
		var tElem = this.travelElem;
		tElem.hide();
	},
	resetPosition:function(obj){  //重置行程表位置
		var _travelPosition = getAllPosition(obj);
		var _scrTop = _travelPosition.scrTop;
		if (_scrTop<140)
		{
			_scrTop = 10;
		}
		else
		{
			_scrTop=parseInt(_scrTop-136);
				
		}
		obj.animate({top: _scrTop},10).slideDown("slow");
	},
	isExist:function(sight){   //判断景区是否存在
		var _temp = [];
		$.each(tripData,function(index,o){
			_temp = _temp.concat(o.Sight);
			
		});
		var _is = false;
		$.map(_temp, function(n){
			if (n.SName==sight.SName)
			{
				_is = true;
				return false;
			}
		}); 
		return _is;	
	},
	isExistHotel:function(hotel1,hotel2){
		var _is = false;
		$.map(hotel2, function(n){
			if (n.HName==hotel1.HName)
			{
				_is = true;
				return false;
			}
		}); 
		return _is;	
	},
	toPlan:function(order,html,obj){  //安排景区行程
		try
		{
			var tempThis = this;
			var _closetop = parseInt($("#hodometerContainer").css("top"));
			$("#TB_Windows").animate({
					top:_closetop+136
				}, 100).animate({
					opacity: "toggle"
				},1000,function(){
					if (tripData[parseInt(order-1)]==undefined || tripData[parseInt(order-1)] == "undefined")
					{
						tripData.push(obj);
						html = '<a href="javascript:;" id="tripSight'+parseInt(order-1)+'0"><img src="'+obj.Sight[0].IMG+'"/><em>'+obj.Sight[0].SName+'</em><h4></h4><h3>￥'+obj.Sight[0].Ticket+'</h3></a>';
						$("#hodometerSightBot").append('<span>'+html+'</span>');
						$("#tripSight"+parseInt(order-1)+"0 h4").click(function(){  //删除景区
							tempThis.deleteSight(obj.Sight[0],order);
						});
						$("#tripSight"+parseInt(order-1)+"0").hover(
	  						function () {
	    						$(this).find("h4").show();
	  						},
	  						function () {
	    						$(this).find("h4").hide();
	  						}
						); 
						//tempThis.addDayInfo(order,order,true);
						$("#dayAmount").text("￥"+obj.DTotal);
					}
					else
					{
						var sLength = $("#hodometerSightBot span:eq("+parseInt(order-1)+") a").size();
						sLength = String(parseInt(order-1)) + String(sLength);
						html = '<a href="javascript:;" id="tripSight'+sLength+'"><img src="'+obj.Sight[0].IMG+'"/><em>'+obj.Sight[0].SName+'</em><h4></h4><h3>￥'+obj.Sight[0].Ticket+'</h3></a>';
						$("#hodometerSightBot span:eq("+parseInt(order-1)+")").append(html);
						//删除景区
						$("#tripSight"+sLength+" h4").click(function(){
							tempThis.deleteSight(obj.Sight[0],order);
						});
						$("#tripSight"+sLength+"").hover(
	  						function () {
	    						$(this).find("h4").show();
	  						},
	  						function () {
	    						$(this).find("h4").hide();
	  						}
						); 
						
						$("#hodometerSightBot span").hide("fast",function(){
							$("#hodometerSightBot span:eq("+parseInt(order-1)+")").show();
							//景区分页
							tempThis.sightPage($("#hodometerSightBot span:eq("+parseInt(order-1)+")"),"sightPage",2);
						});
						tripData[parseInt(order-1)].Sight=tripData[parseInt(order-1)].Sight.concat(obj.Sight);
						//计算当天费用
						tripData[parseInt(order-1)].DTotal = parseInt(tripData[parseInt(order-1)].DTotal) + parseInt(obj.DTotal);
						$("#dayAmount").text("￥"+tripData[parseInt(order-1)].DTotal);
						//tempThis.addDayInfo(tripData.length,order,true);
					}
					//加载酒店信息
					tempThis.loadHotelInfo(obj.Sight[0].SID,order,false);
				}
			);
		}
		catch(e){
			
		}
	},
	deleteSight:function(obj,day){  //删除景区信息
		try
		{
			day = parseInt(day-1);
			var tempThis = this;
			$.each(tripData[day].Sight,function(index,json){
				if(json.SName == obj.SName)
				{
					tripData[day].Sight.splice(index,1);
					tripData[day].DTotal = parseInt(tripData[day].DTotal-obj.Ticket);
					$("#dayAmount").text(tripData[day].DTotal);
					$("#hodometerSightBot span:eq("+day+") a:eq("+index+")").remove();
				}
			});
			if(tripData[day].Sight.length==0&&tripData[day].Hotel=="")
			{
				tripData.splice(day,1);
				$("#hodometerSightBot span:eq("+day+")").remove();
				this.addDayInfo(tripData.length,tripData.length,false);
			}
			tempThis.sightPage($("#hodometerSightBot span:eq("+day+")"),"sightPage",2);
		}
		catch(e){
		}
	},
	addDayInfo:function(maxnum,pagecurrent,init){   //添加行程单天数
		var _dayHtml = "";
		var _temp = "";
		var _total = 0;
		var tempThis = this;
		for(var i=1;i<=maxnum;i++)
		{
			if (i==maxnum)
				_dayHtml += '<a href="javascript:;" class="current">'+i+'</a>';
			else
				_dayHtml += '<a href="javascript:;">'+i+'</a>';
		}
		$("#hodometerDayNum").html(_dayHtml);
		if (init)
			$("#hodometerHotels").append("<span></span>");
		$("#hodometerDayNum a").click(function(){
			_temp = parseInt($(this).text());
			_temp = parseInt(_temp-1);
			$("#hodometerDayNum a").removeClass("current");
			$("#hodometerDayNum a:eq("+_temp+")").addClass("current");
			$("#dayAmount").text("￥"+tripData[_temp].DTotal); //当天消费
			$("#hodometerSightBot span").hide("fast",function(){
				$("#sightPage").html("");
				$("#hodometerSightBot span:eq("+_temp+")").show();
				//景区分页
				tempThis.sightPage($("#hodometerSightBot span:eq("+_temp+")"),"sightPage",2);
			});
			//酒店信息
			$("#hodometerHotels span").hide("fast",function(){
				$("#hodometerHotels span:eq("+_temp+")").show();
			});
			if(cirHotelInfo.length>0)
			{
				var sightjson = [];   //景区信息格式化
				$.each(tripData[_temp].Sight,function(m,s){
					var domnum =  String(_temp) + String(m);
					var sight = {
						Name:s.SName,
						Url:'http://jq.ipow.cn/szhys',
						Type:'Sight',
						Latitude:s.Latitude,
						Longitude:s.Longitude,
						Price:s.Ticket,
						ImageSrc:s.IMG,
						Address:s.Address,
						CommCount:0,
						PicCount:0,
						SightType:'海洋主题公园',
						DomID:'tripSight'+domnum+'',
						markerPic:"/images/flv_04.gif"
					};
					sightjson.push(sight);
				});
				tempThis.hotelPage(_temp,7,1,sightjson);
			}
			
		});
		if (pagecurrent > 0)
		{
			$("#hodometerDayNum a").eq(parseInt(pagecurrent-1)).trigger('click');
		}
		tempThis.statistics();
		document.cookie = "TourData="+JSON.stringify(tripData); //保存历史数据
	},
	hotelPage:function(daynum,pagemax,pagecurrent,sightjson){   //酒店分页
		var tempThis = this;
		var hotelMap = [];
		hotelMap = hotelMap.concat(sightjson);
		var startindex = endindex=0;
		//if (tempThis.cirHotelList[parseInt(daynum)] == undefined)
		{
			//tempThis.loadHotelInfo(tripData[parseInt(daynum)].Sight[0].SID,parseInt(daynum+1),false);
			//return false;
		}
		var hotelcount = cirHotelInfo[parseInt(daynum)].length;
		var allPage = Math.ceil(hotelcount/pagemax);
		
		if (allPage>=pagecurrent)
		{
			switch(pagecurrent){
				case 1:
					$("#hotelPage").html('<a href="javascript:;" id="nextHotelPage">下一页</a>');
					$("#nextHotelPage").click(function(){
						tempThis.hotelPage(daynum,pagemax,parseInt(pagecurrent+1),sightjson)						   
					});
					break;
				case allPage:
					$("#hotelPage").html('<a href="javascript:;" id="prevHotelPage">上一页</a>');
					$("#prevHotelPage").click(function(){
						tempThis.hotelPage(daynum,pagemax,parseInt(pagecurrent-1),sightjson)						   
					});
					break;
				default:
					$("#hotelPage").html('<a href="javascript:;" id="nextHotelPage">下一页</a><a href="javascript:;" id="prevHotelPage">上一页</a>');
					$("#nextHotelPage").click(function(){
						tempThis.hotelPage(daynum,pagemax,parseInt(pagecurrent+1),sightjson)						   
					});
					$("#prevHotelPage").click(function(){
						tempThis.hotelPage(daynum,pagemax,parseInt(pagecurrent-1),sightjson)						   
					});
					break;
			};
			startindex = (pagecurrent-1)*pagemax;
			endindex = pagecurrent*pagemax;
			if (endindex>hotelcount)
				endindex = hotelcount;
			$("#CirHotelList").html("");
			var sightCount = sightjson.length;
			$.each(cirHotelInfo[parseInt(daynum)].slice(startindex,endindex),function(index,h){
				_html = '<li id="hotel'+h.HotelID+'"><a href="http://hotel.ipow.cn/'+h.HotelID+'.shtml" title="'+h.HName+'"><img src="/images/icon/htop'+parseInt(index+1)+'.jpg" border="0"/><span>'+h.HName+'</span><em>￥'+h.HPrice+'</em></a><span class="addHotel" id="hotelOpration'+index+'">添加</span></li>';	
				$("#CirHotelList").append(_html);
				$("#hotelOpration"+index+"").click(function(){tempThis.addHotel(this,h);});
				var hoteljson = {
					Name: h.HName,
					Url: 'http://hotel.ipow.cn/3325.shtml',
					Type: 'Hotel',
					Latitude:h.Latitude,
					Longitude:h.Longitude,
					Price:h.HPrice,
					ImageSrc: '/images/nopic116.jpg',
					Address: h.Address,
					CommCount: 0,
					PicCount: 0,
					HotelType: '四星级',
					DomID: 'hotel'+h.HotelID+'',
					OrderID: parseInt(index+1)
				};
				hotelMap.push(hoteljson);
			});
			mapinitialize(hotelMap, 'tripMap', 'tripMapTipPanel',false);
			//addTwoMap(hotelMap);
		}
		
	}, 
	sightPage:function(obj1,obj2,pagemax){   //景区分页
		var _size = $(obj1).find("a").size();
		var _pageTotal = Math.ceil(_size/pagemax);
		var _pageHtml = "";
		if (_pageTotal>=1)
		{
			for(var i=1;i<=_pageTotal;i++)
			{
				_pageHtml += '<a href="javascript:;">'+i+'</a>';
			}
			$("#"+obj2).html(_pageHtml);
			$("#"+obj2 + " a").click(function(){
				var _temp1 = $(this).text();
				var _temp2 = pagemax*(parseInt(_temp1)-1);
				$("#"+obj2+" a").removeClass("current1");
				$("#"+obj2+" a:eq("+parseInt(_temp1-1)+")").addClass("current1");
				$(obj1).find("a:slice("+parseInt(_temp2)+","+parseInt(_temp2+pagemax)+")").show().parent().find("a:lt("+parseInt(_temp2)+")").hide();
			});
			$("#"+obj2 + " a").eq(parseInt(_pageTotal-1)).trigger('click');
		}
		else
		{
			$("#"+obj2).html("");
		}
	},
	statistics:function(){   //统计行程信息
		var _total = 0;
		var _sights = 0;
		$("#TravelDays").text(tripData.length);//更新行程天数
		$.map(tripData,function(n){
			_total = parseInt(_total) + parseInt(n.DTotal);
			_sights = parseInt(_sights) + parseInt(n.Sight.length);
		});
		$("#TravelSights").text(_sights);//更新行程天数
		$("#TravelCost").text("￥"+_total);
	},
	loadHotelInfo:function(sightid,num,isload){  //加载酒店信息
		try
		{
			var tempThis = this;
			var _html = "";
			var njson = {},cirhotel=[];
			num = parseInt(num-1);
			$("#CirHotelList").html("");
			$.getScript(iPowApi + "IpowAPI/Hotel/Requset/GetHotelInfo.aspx?RequestType=GetCircleHotelByParkID&ParkID="+sightid+"&temp=" + Math.random(),function(){																																									   cirhotel=[];
				$.each(hotelJson,function(index,json){
					njson = {
						HotelID:json.ID,
						HName:json.HotelName,
						Star:json.Starrating,
						Address:json.Address,
						HPrice:parseInt(json.MinPrice),
						Latitude:json.latitude,
						Longitude:json.longitude
					};
					
					if (cirHotelInfo[parseInt(num)]==undefined || cirHotelInfo[parseInt(num)] == "undefined")
						cirhotel.push(njson);	
					else
					{
						if(!tempThis.isExistHotel(njson,cirHotelInfo[parseInt(num)]))
							cirhotel.push(njson);
					}
				});
				if (cirHotelInfo[parseInt(num)]==undefined || cirHotelInfo[parseInt(num)] == "undefined")
				{
					cirHotelInfo[parseInt(num)] = cirhotel;
				}
				else
				{
					cirHotelInfo[parseInt(num)] = cirHotelInfo[parseInt(num)].concat(cirhotel);
				}
				if (!isload)
				{
					//添加行程菜单
					tempThis.addDayInfo(tripData.length,parseInt(num+1),true);
				}
				
			});
		}
		catch(e){
		}
		
		
	},
	addHotel:function(obj,hjson){  //添加酒店到行程
		var tempThis = this;
		var _hname = hjson.HName;  //酒店名称
		var _hprice = hjson.HPrice;   //酒店价格
		var _haddress = hjson.Address;
		var _daynum = parseInt(tripData.length);
		var _hotelHtml = '<span><h3>'+_hname+'</h3><em>￥'+_hprice+'</em><p>'+_haddress+'</p></span>';
		if (_daynum>1)
		{
			//弹出层表单数据
			var _tempHtml = '<div class="TB_Form"><span><label>选择行程：</label>';
			_tempHtml += '<select name="selTravelHotel" id="selTravelHotel" class="selStyle">';
			for (var j=1;j<=_daynum;j++)
			{
				if (j==_daynum)
					_tempHtml += '	<option value="'+j+'" selected="selected">第'+j+'天</option>';
				else
					_tempHtml += '	<option value="'+j+'">第'+j+'天</option>';
			}
			_tempHtml += '</select><a href="javascript:;" class="btnSubmit" id="btnSetHotel"></a></span></div>';
			//弹出图层
			$(obj).TBwin({
				width:300,
				height:100,
				title:"行程安排",
				datahtml:_tempHtml,
				datatype:"html",
				isBG:false,
				callback:function(){
					$("#btnSetHotel").click(function(){
						tempThis.toPlanHotel($("#selTravelHotel option:selected").attr("value"),_hotelHtml,hjson);
					}
				)}
			});
		}
		else
		{
			if (tripData[0].Hotel.HPrice > 0)
				tripData[0].DTotal = parseInt(tripData[0].DTotal) - parseInt(tripData[0].Hotel.HPrice);
			tripData[0].Hotel = hjson;
			var _dtotal = parseInt(tripData[0].DTotal)+parseInt(hjson.HPrice);   //加入酒店费用
			tripData[0].DTotal = _dtotal;
			tempThis.addDayInfo(tripData.length,1,false);
			$("#hodometerHotels span:eq(0)").replaceWith(_hotelHtml);
			document.cookie = "TourData="+JSON.stringify(tripData); //保存历史数据
		}
	},
	toPlanHotel:function(day,html,data){  //将酒店信息添加到行程
		var _closetop = parseInt($("#hodometerContainer").css("top"));
		var tempThis = this;
		$("#TB_Windows").animate({
				top:_closetop+136
			}, 100).animate({
				opacity: "toggle"
			},1000,function(){
				if (tripData[parseInt(day-1)].Hotel.HPrice > 0)
					tripData[parseInt(day-1)].DTotal = parseInt(tripData[parseInt(day-1)].DTotal) - parseInt(tripData[parseInt(day-1)].Hotel.HPrice);
				tripData[parseInt(day-1)].Hotel = data;
				tripData[parseInt(day-1)].DTotal = parseInt(tripData[parseInt(day-1)].DTotal) + parseInt(data.HPrice);  //加入酒店费用
				tempThis.addDayInfo(tripData.length,day,false);
				$("#hodometerHotels span:eq("+parseInt(day-1)+")").replaceWith(html);
				//document.cookie = "TourData="+JSON.stringify(tripData); //保存历史数据
			}
		);
	},
	save:function(obj,type){    //行程保存
		try
		{
			if((tripData==""||tripData[0].Sight==undefined||tripData[0].Sight=="")&&tripData.length==0)
			{
				alert("您还未添加景区到行程表里:)");
				return false;
			}
			var tempThis = this;
			jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?type=chk&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){
				var username = getCookie("UserName");
				if (username == "null"||username=="")
				{
					tempThis.login(obj,"save");
					return false;
				}
				else
				{
					var _tempHtml = '<div class="TB_Form"><span><label>行程名称：</label><input id="TourName" type="text" class="txtInput"/><em>*</em></span>';
					_tempHtml += '<span style="height:55px;"><label>行程标签：</label><textarea name="TourRemark" id="TourRemark" cols="20" rows="4"></textarea></span>';
					_tempHtml += '<span><label id="subLoading">&nbsp;</label><a href="javascript:;" class="btnSubmit" id="btnTourSave"></a></span></div>';
					//弹出图层
					$(obj).TBwin({
							width:320,
							height:165,
							title:"保存行程",
							datahtml:_tempHtml,
							datatype:"html",
							isBG:false,
							callback:function(){
								$("#btnTourSave").click(function(){
									var _tourname = $("#TourName").val();
									if (_tourname == "")
									{
										alert("请输入行程名称:)");
										$("#TourName").focus();
										return false;
									}
									var tourJson = {
										TourName:_tourname,
										TourRemark:$("#TourRemark").val(),
										UserName:username,
										Destination:$("#TravelArea").text(),
										DayNum:$("#TravelDays").text(),
										TravelCost:$("#TravelCost").text()
									};
									$("#subLoading").text("提交中…");
									$(this).hide();
									tempThis.submitdata(tourJson,type);
								}
							)}
						});
				}
																																							
			});	
		}
		catch(e){
		}
	},
	submitdata:function(obj,type){
		var _tourPlan = {
			PlanTitle:escape(obj.TourName),
			UserName:escape(obj.UserName),
			Remark:escape(obj.TourRemark),
			Destination:escape(obj.Destination),
			Days:tripData.length
		};
		var _tourPlanDetail = [];
		$.each(tripData,function(index,planJson){
			$.map(planJson.Sight,function(sight){
				var _sightDetail = {
					SightIDOrHotelID:sight.SID,
					CurrentPrice:sight.Ticket,
					Remark:"",
					DayID:planJson.DayID,
					DetailType:"sight"
				};
				_tourPlanDetail.push(_sightDetail);
			});
			var _sightDetail = {};
			if (planJson.Hotel!="")
			{
				var _tempPrice = Math.round(planJson.Hotel.HPrice);
				_sightDetail = {
					SightIDOrHotelID:planJson.Hotel.HotelID,
					CurrentPrice:_tempPrice,
					Remark:"",
					DayID:planJson.DayID,
					DetailType:"hotel"
				};
				_tourPlanDetail.push(_sightDetail);	
			}
								
		});
		var Plan=JSON.stringify(_tourPlan);
		var PlanDetail = JSON.stringify(_tourPlanDetail);
		if (type == "edit")
			jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/TourPlanHandler.ashx?Type=SaveTourPlan&CallBack=iPowEdit.savesuccess&Plan="+Plan+"&PlanDetail="+PlanDetail+"");
			else
			jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/TourPlanHandler.ashx?Type=SaveTourPlan&CallBack=iPowDraw.savesuccess&Plan="+Plan+"&PlanDetail="+PlanDetail+"");
	},
	clearHistory:function(){
		var date=new Date();
    	date.setTime(date.getTime()-10000);
    	document.cookie="TourData=; expire="+date.toGMTString();
		cirHotelInfo = [];
		tripData = [];
		this.isScroll = false;
		$("#hodometerSightBot").html("");
		$(window).unbind("scroll");
		$("#hodometerContainer").hide();
		alert("清楚历史记录成功:)");
	},
	tripMap:function(){  //线路地图
		var mapJson = "";
		var sightJson = [],hotelJson=[];
		$.each(planAll,function(tindex,tripJson){
			$.each(tripJson.Sight,function(sindex,s){
				var sight = {
				Name:s.SName,
				Url:'http://jq.ipow.cn/szhys',
				Type:'Sight',
				Latitude:s.Latitude,
				Longitude:s.Longitude,
				Price:s.Ticket,
				ImageSrc:s.IMG,
				Address:s.Address,
				CommCount:0,
				PicCount:0,
				SightType:'海洋主题公园',
				DomID:''
				};
				sightJson.push(sight);						  
			});
			var hotel = {
				Name:tripJson.Hotel.HName,
				Url:'http://hotel.ipow.cn/szhys',
				Type:'hotel',
				Latitude:tripJson.Hotel.Latitude,
				Longitude:tripJson.Hotel.Longitude,
				Price:tripJson.Hotel.HPrice,
				ImageSrc:tripJson.Hotel.IMG,
				Address:tripJson.Hotel.Address,
				CommCount:0,
				PicCount:0,
				SightType:'海洋主题公园',
				DomID:''
			};
			hotelJson.push(hotel);
							
		});
		sightJson = sightJson.concat(hotelJson);
		mapinitialize(sightJson, 'gMap', 'jxMapTipPanel',false);
	},
	history:function(){   //历史记录
		var _historyData = getCookie("TourData");
		var tempThis = this;
		if (_historyData!="" && _historyData != "undefined" && _historyData !=undefined)
		{
			$travel = tempThis.travelElem;
			if ($travel.is(":hidden"))
			{
				tripData = JSON.parse(_historyData);
				var _sightHtml = "",_hotelHtml="";
				$("#hodometerSightBot").html(_sightHtml);
				$("#hodometerHotels").html(_hotelHtml);
				
				var _travelPosition = getAllPosition($travel);
				var _scrTop = _travelPosition.scrTop;
				if (_scrTop<140)
				{
					_scrTop = 10;
				}
				else
				{
					_scrTop=parseInt(_scrTop-136);
				}
				$travel.animate({top: _scrTop},10).slideDown("fast",function(){
					$.each(tripData,function(index,json){
						_sightHtml = "";
						$("#hodometerSightBot").append('<span style="display:none;"></span>');
						$("#TravelArea").text(json.Destination);
						$.each(json.Sight,function(sindex,sight){
							var domid = String(index) + String(sindex);
							_sightHtml = '<a href="javascript:;" id="tripSight'+domid+'"><img src="'+sight.IMG+'"/><em>'+sight.SName+'</em><h4></h4><h3>￥'+sight.Ticket+'</h3></a>';
							$("#hodometerSightBot span:eq("+index+")").append(_sightHtml);
							//删除景区
							$("#tripSight"+domid+" h4").click(function(){
								tempThis.deleteSight(sight,parseInt(index+1));
							});
							$("#tripSight"+domid+"").hover(
								function () {
									$(this).find("h4").show();
								},
								function () {
									$(this).find("h4").hide();
								}
							);
						});
						if(json.Hotel=="")
							_hotelHtml = '<span></span>';
						else
							_hotelHtml = '<span><h3>'+json.Hotel.HName+'</h3><em>￥'+json.Hotel.HPrice+'</em><p>'+json.Hotel.Address+'</p></span>';
						$("#hodometerHotels").append(_hotelHtml);
						$.map(json.Sight,function(sight){
							tempThis.loadHotelInfo(sight.SID,parseInt(index+1),false);
						});
					});													 
					tempThis.wscroll();  //滚动事件	
				});		
			}
		}
	},
	login:function(obj,type){   //用户登录
		var _loginHtml = "";
		var tempThis = this;
		_loginHtml = '<div class="TB_Cotainer">';
		_loginHtml += '<div class="TB_Login" id="TB_UserForm"><h3>请输入您的登录信息</h3><span><label>用户名：</label><input id="UserName" type="text" class="txtInput"/><em>*</em></span>';
		_loginHtml += '<span><label>密　码：</label><input id="Password" type="password" class="txtInput"/><em>*</em></span>';
		_loginHtml += '<span><label>&nbsp;</label><a href="javascript:;" class="btnLogin" id="btnLogin" title="登录"></a></span></div>';
		_loginHtml += '<h4>没有账号?<a href="javascript:;" id="btnRegister">加入我们</a></h4>';
		_loginHtml += '</div>';
		var _isBg = false;
		if (type == "login")
		{
			_isBg = true;
		}
		$(obj).TBwin({
			width:600,
			height:280,
			title:"用户登录",
			datahtml:_loginHtml,
			datatype:"html",
			isBG:_isBg,
			callback:function(){
				$("#btnRegister").click(function(){
					tempThis.register(obj,"loading");						 
				});
				$("#btnLogin").click(function(){
					var _username = $("#UserName").val();
					var _password = $("#Password").val();
					if (_username == "")
					{
						alert("请输入您的用户名:)");
						$("#UserName").focus()
						return false;
					}
					if (_password == "")
					{
						alert("请输入您的密码:)");
						$("#Password").focus();
						return false;
					}
					if (type == "save")
					{
						jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?username="+escape(_username)+"&password="+escape(_password)+"&type=login&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){
						tempThis.save(obj);																																																																																									});	
					}
					else
					{
						jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?username="+escape(_username)+"&password="+escape(_password)+"&type=login&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){
						$("#TB_Windows").animate({
							top:136
							}, 100).animate({
								opacity: "toggle"
							},1000,function(){$("#TB_WinBg").remove();});																																																																																														   						});
					}
					
				});
			}
		});
	},
	saveuser:function(user){   //保存用户信息
		if (user.ChkLogin)
		{
			document.cookie = "UserName="+user.UserName;
			$("#loginUserInfo").html('欢迎您，'+user.UserName+'！<a href="javascript:;" id="logout" onclick="iPowDraw.logout()" title="退出">退出</a>');
		}
		else
		{
			document.cookie = "UserName="+user.UserName;
		}
	},
	logout:function(){  //用户登出
		var _this = this;
		jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?type=out&temp="+Math.random(),function(){
			document.cookie = "UserName="+"";
			$("#loginUserInfo").html('<a href="javascript:;" id="goLogin" title="用户登录">登录</a>&nbsp;&nbsp;<a href="javascript:;" id="goRegister" title="新用户注册">注册</a>');
			$("#goLogin").click(function(){
				_this.login(this,"login");			  
			});
			$("#goRegister").click(function(){
				iPowDraw.register(this,"reg");				   
			});
		});	
	},
	checkuser:function(){  //用户验证
		jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?type=chk&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){
			var _username = getCookie("UserName");																											   
		});
	},
	register:function(obj,type){  //用户注册
		var _this = this;
		var _register ="";
		_register += '<div class="TB_Cotainer">';
		_register += '<div class="TB_Login"><h3>请输入您的个人信息</h3><span><label>用户名：</label><input id="regUserName" type="text" class="txtInput"/><em>*</em></span>';
		_register += '<span><label>密　码：</label><input id="regPassword" type="password" class="txtInput"/><em>*</em></span>';
		_register += '<span><label>确认密码：</label><input id="regPassword1" type="password" class="txtInput"/><em>*</em></span>';
		_register += '<span><label>Email：</label><input id="regEmail" type="text" class="txtInput"/><em>*</em></span>';
		_register += '<span><label>&nbsp;</label><a href="javascript:;" class="btnSubmit" id="rebtnSubmit" title="提交"></a><a href="javascript:;" class="btnReset" id="btnReset" title="重置"></a></span></div>';
		_register += '<h4>已有账号?<a href="javascript:;" id="btnLogin">现在登录</a></h4>';
		_register += '</div>';
		$(obj).TBwin({
			width:600,
			height:280,
			title:"用户注册",
			datahtml:_register,
			datatype:"html",
			isBG:true,
			callback:function(){
				$("#btnLogin").click(function(){
					_this.login(this,"login"); 
				});
				$("#regUserName").blur(function(){
					_this.existreuser(this);
				});
				$("#rebtnSubmit").hide();
				$("#rebtnSubmit").click(function(){
					var _username = $.trim($("#regUserName").val());
					var _password = $.trim($("#regPassword").val());
					var _password1 = $.trim($("#regPassword1").val());
					var _email = $.trim($("#regEmail").val());
					if (_username == "")
					{
						alert("请输入注册用户名:)");
						$("#regUserName").focus();
						return false;
					}
					if (_password == "")
					{
						alert("请输入的密码:)");
						$("#regPassword").focus();
						return false;
					}
					if (_password1 == "")
					{
						alert("请输入确认密码:)");
						$("#regPassword1").focus();
						return false;
					}
					if(_password!=_password1)
					{
						alert("密码和确认密码不一致，请重新输入密码:)");
						$("#regPassword").focus();
						return false;
					}
					if(_email == "")
					{
						alert("请输入Email:)");
						$("#regEmail").focus();
						return false;
					}
					else {
						if (!isEmail(_email)) {
							alert("您的电子邮箱格式错误:)");
							$("#regEmail").select();
							return false;
						}
					}
					if (type == "reg")
					{
						jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?username="+escape(_username)+"&password="+escape(_password)+"&email="+escape(_email)+"&type=register&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){
						$("#TB_Windows").animate({
						  top:136
						  }, 100).animate({
							  opacity: "toggle"
						  },1000,function(){
							  $("#TB_WinBg").remove();
							  alert("注册成功！");
						  });																																																																																																																																																																																																													   });
					}
					else
					{
						jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?username="+escape(_username)+"&password="+escape(_password)+"&email="+escape(_email)+"&type=register&CallBack=iPowDraw.saveuser&temp="+Math.random(),function(){																																																											   _this.save(obj);});
					}
					
					
				});
			}
		});
	},
	userexit:function(obj){
		if (obj.Type=="Exist")
		{
			$("#rebtnSubmit").hide();
			alert("用户名已经存在！")
			$("#regUserName").select();
		}
		else if (obj.Type=="NotExist")
		{
			$("#rebtnSubmit").show();
		}
	},
	existreuser:function(obj)
	{
		var _username = $.trim($(obj).attr("value"));
		if (_username=="")
		{
			alert("请输入注册用户名:)");
			$("#regUserName").focus();
			return false;
		}
		jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/UserLogin.ashx?type=exist&username="+escape(_username)+"&CallBack=iPowDraw.userexit&temp="+Math.random());
	},
	savesuccess:function(obj){    //数据保存成功
		if (obj.Type == "OK")
		{
			var _closetop = parseInt($("#hodometerContainer").css("top"));
			var tempThis = this;
			$("#TB_Windows").animate({
					top:_closetop+136
				}, 100).animate({
					opacity: "toggle"
				},1000,function(){
					
					var date=new Date();
					date.setTime(date.getTime()-10000);
					document.cookie="TourData=; expire="+date.toGMTString();
					cirHotelInfo = [];
					tripData = [];
					this.isScroll = false;
					$("#hodometerSightBot").html("");
					$(window).unbind("scroll");
					$("#hodometerContainer").hide();
					$("#TB_Windows").hide();
					$("#btnTourSave").show();
					window.location.href = "http://192.168.1.65:300" + obj.Path;
				}
			);
		}
		
	},
	iSearch:function(q,type){    //线路搜索
		var _this = this;
		switch(type){
			case "search":
				var _keyword = $.query.get("q");
				var _days = $.query.get("days");
				var _live = $.query.get("live");
				var _const = $.query.get("const");
				$("#sTripInfo").html("");
				if (_keyword == "" || _keyword == "null")
				{
					location.href = "http://www.ipow.cn/"
				}
				if (_days!= "")
				{
					$("#txtDays").val(_days);
					$("#sTripInfo").append("　行程天数："+_days+"")
					this.filters.DayNum = [[parseInt(_days),parseInt(_days)]];
				}
				if (_live!="")
				{
					$("#txtLive").val(_live);
					this.filters.Live = _live;
				}
				if (_const!="")
				{
					$("#txtConst").val(_const);
					$("#sTripInfo").append("　行程预算：¥"+_const+"以内")
					this.filters.Const = [[0,parseInt(_const)]];
				}
				if (_keyword!="")
				{
					$("#txtKeyword").val(_keyword);
					$("#fKeyword").text(_keyword);
					jQuery.getScript(iPowApi + "IpowAPI/Search.ashx?q="+escape(_keyword)+"&type=tour&CallBack=iPowDraw.searchComplete&temp="+Math.random());
				}
				break;
			case "gotour":
				var _keyword = $.trim($("#txtKeyword").val().replace("请输入关键字 如海南",""));
				if (_keyword == "")
				{
					alert("请输入搜索关键字:)");
					$("#txtKeyword").select();
					return false;
				}
				var _days = $.trim($("#txtDays").val().replace("天数",""));
				var _live = $.trim($("#txtLive").val().replace("住宿标准",""));
				var _const = $.trim($("#txtConst").val().replace("预算金额",""));
				var _query = $.query.set("q", _keyword).toString();
				if (_days!="")
				{
					_query += "&days=" + encodeURIComponent(_days);
				}
				if (_live!="")
				{
					_query += "&live=" + encodeURIComponent(_live);
				}
				if (_const!="")
				{
					_query += "&const=" + encodeURIComponent(_const);
				}
				var _url = "/search/"+_query;
				window.location.href = _url;
				break;
			default:
				break;
		}
	},
	searchComplete:function(obj){   //搜索成功
		var _this = this;
		if (obj.Type == "OK")
		{
			tripListData = obj.Result;
			globalTripData = obj.Result;
			listMap.init(globalTripData,_this.filters);
			$("#priceAsc").trigger("click");
		}
	},
	sPage:function(obj,current){
		var _this = this;
		if (current == undefined)
		{
			current = 1;
		}
		var _count = obj.length;
		var _pagecount = Math.ceil(_count/_this.resultSize);
		var _html = "";
		var _start = (current-1)*_this.resultSize;
		var _end = current*_this.resultSize;
		if (_end>_count)
			_end = _count;
		$.each(obj.slice(_start,_end),function(index,rjson){
			_html += '<a href="'+rjson.Url+'"  class="tripList" target="_blank">\
				<img src="'+rjson.Phone+'" />\
				<h3>'+rjson.PlanTitle+'</h3>\
				<dl>\
				   <dt>\
					   <span>￥<font class="fPrice">'+rjson.Const+'</font>/全程</span>\
					   <em></em>\
				   </dt>\
				   <dd>途经景点：'+rjson.Sights+'</dd>\
				   <dd>天数：'+rjson.DayNum+'天</dd>\
				   <dd>住宿：'+rjson.Hotels+'</dd>\
				   <dd>关键字：'+rjson.Remark+'</dd>\
			   </dl>\
			</a>';					   
		});
		$("#ResultList").html(_html);
		_this.pageUI(current,_pagecount,obj)
	},
	pageUI:function(pageindex,pagecount,obj){
		var _this = this;
		var UiPageHtml = "";
		if (pagecount != 1) 
		{
        	
       		if (pageindex <= 1) {
            	//UiPageHtml += "上一页&nbsp;&nbsp;";
        	}
        	else {
            //添加上一页的超级链接
            if (pageindex > 1) {
                UiPageHtml = '<a href="javascript:;" title="上一页"  style="width:50px;">上一页</a>' + UiPageHtml;
            }
        }
        var i;
        if (pageindex <= 10 && pagecount <= 10) {
            for (i = 1; i <= pagecount; i++) {
                if (i == pageindex) {
                    UiPageHtml = '<span>' + i + ' </span>' + UiPageHtml;
                }
                else {
                    UiPageHtml = '<a href="javascript:void(0);">' + i + '</a>' + UiPageHtml;
                }
                
            }
        }
        else 
            if (pagecount >= 10 && pageindex <= 5) {
                for (i = 1; i <= 10; i++) {
                    if (i == pageindex) {
                        UiPageHtml = "<span>" + i + " </span>" + UiPageHtml;
                    }
                    else {
                        UiPageHtml = '<a href="javascript:void(0);">' + i + '</a>' + UiPageHtml;
                    }
                    
                }
            }
            else 
                if ((pageindex + 5) <= pagecount) {
                    for (i = (pageindex - 4); i <= (pageindex + 5); i++) {
                        if (i == pageindex) {
                            UiPageHtml = "<span>" + i + " </span>" +UiPageHtml;
                        }
                        else {
                            UiPageHtml = '<a href="javascript:void(0);">' + i + '</a>' + UiPageHtml;
                        }
                        
                    }
                    
                }
                else {
                    for (i = (pageindex - 4); i <= pagecount; i++) {
                        if (i == pageindex) {
                            UiPageHtml = "<span>" + i + " </span>" + UiPageHtml;
                        }
                        else {
                            UiPageHtml = '<a href="javascript:void(0);">' + i + '</a>' + UiPageHtml;
                        }
                        
                    }
                    
                }
		}
        if (pageindex < pagecount&&pagecount>1) {
                UiPageHtml = '<a href="javascript:;" title="下一页" style="width:50px;">下一页</a>' + UiPageHtml;
        }
		$("#RusultPage").html('<div class="pageContainer">' + UiPageHtml + '</div>');
		$("#RusultPage a").unbind("click");
		$("#RusultPage a").click(function(){
			var _current = $(this).text();
			switch(_current){
				case "上一页":
					_this.sPage(obj,parseInt(pageindex-1));
					break;
				case "下一页":
					_this.sPage(obj,parseInt(pageindex+1));
					break;
				default:
					_this.sPage(obj,_current);
					break;
			}
		});
	},
	toolPanel:function(height,resize){  //底部工具条
		var _this = this;
		if (height==undefined||height=="")
			height = _this.toolHeight;
		var _clientInfo = getAllPosition();
		var _top = _clientInfo.offHeight-height;
		if (resize == undefined)
		{
			$("#toolPanel").css("top",""+_clientInfo.offHeight+"px");
			$("#toolPanel").animate({
				top:_top			
			},800,function(){
				bindMin();
			});
		}
		else
		{
			bindMin();
			if ($("#miniTool:hidden"))
			{
				$("#toolPanel").css({"top":""+(_top+ height - 32)+"px","width":""+_clientInfo.offWidth+"px"});
				$("#miniTool").hide();
				$("#resTool").show();
			}
			else
			{
				$("#toolPanel").css({"top":""+(_top)+"px","width":""+_clientInfo.offWidth+"px"});
				$("#miniTool").show();
				$("#resTool").hide();
			}
			
		}
		function bindMin(){
			$("#miniTool").unbind();
			$("#miniTool").click(function(){
				$("#miniTool").hide("fast");	
				$("#toolPanel").animate({
					top:_top + height - 32			
				},800,function(){
					$("#toolContainer").hide("fast",function(){
						$("#resTool").show("fast");							 
					});
				});					  
			});
			$("#resTool").unbind();
			$("#resTool").click(function(){
				$("#toolContainer").show()
				$("#resTool").hide("fast");	
				$("#toolPanel").animate({
					top:_top			
				},800,function(){
					$("#miniTool").show("fast");
				});					  
			});
		}
		
		
		
		
	}
	
	
	
}  

//行程编辑
function EditTravel(element,parameters)
{
	this.element = null;
	this.parameters = parameters;
	this.travelElem = $("#EditHodometer");
	this.tabDays = $("#tabDays");
	this.isScroll = false;
	this.isChange = false;
	this.cirSight = null;
	this.cirHotel = null;
	this.isEdit = false;
}
EditTravel.prototype = {
	init:function(){
		var _this = this;
		_this.cirSight = sightMap;
		_this.cirHotel = hotelMap;
		//行程天数按钮事件
		var _tabObj = _this.tabDays.find("a");
		$.each(_tabObj,function(index,tab){
			$(tab).click(function(){
				_this.tabClick(this,index);  
			})				
		});
		//绑定景区删除
		_this.travelElem.find(".aDeleteSight").click(function(){
			_this.delSight(this);												  
		});
		//绑定酒店删除
		_this.travelElem.find(".aDeleteHotel").click(function(){
			_this.delHotel(this);												  
		});
		tripData = planAll;
		this.tempTripData = planAll;
		_this.cirInit(0);
		
	},
	tabClick:function(obj,day){
		var _this = this;
		_this.tabDays.find("a").removeClass("current");
		_this.tabDays.find("a:eq("+day+")").addClass("current");
		_this.travelElem.find(".tourContainer").slideUp(500).parent().find(".tourContainer:eq("+day+")").slideDown(500);
		_this.cirInit(day);

	},
	cirInit:function(day){
		var _this = this;
		$("#cirContainer .rightCirInfo").slideUp(500).parent().find("..rightCirInfo:eq("+day+")").slideDown(500);
		$("#cirTab a").unbind("click");
		$("#cirTab a").click(function(){
			$(this).parent().find("a").removeClass("current");
			$(this).addClass("current");
			var sightjson = [];
			$.each(tripData[parseInt(day)].Sight,function(index,sjson){
				var _tempDomID = 'sight'+sjson.SID+'';
				var _sightType = $("#" + _tempDomID+" h3").text().replace(sjson.SName,"");
				var temp = {
					Name: sjson.SName,
					Url: $("#" + _tempDomID+" a").attr("href"),
					Type: "Sight",
					Latitude:sjson.Latitude,
					Longitude:sjson.Longitude,
					Price:sjson.Ticket,
					ImageSrc: sjson.IMG,
					Address: sjson.Address,
					CommCount: 0,
					PicCount: 0,
					SightType: _sightType,
					DomID: 'sight'+sjson.SID+'',
					markerPic:"/images/flv_04.gif"
				};
				sightjson.push(temp);
			})
			
			if ($(this).attr("rel") == "Sight")
				_this.paging(day,5,1,sightjson,_this.cirSight,"Sight");
			else if ($(this).attr("rel") == "Hotel")
				_this.paging(day,5,1,sightjson,_this.cirHotel,"Hotel");
			else
				_this.paging(day,5,1,sightjson,repastMap,"Repast");
		});
		$("#cirTab a:first").trigger("click");
	},
	addSight:function(obj){
		var _this = this;
		if (obj.Type == "OK")
		{
			var _temp  = JSON.parse(obj.SightEntity);
			var sightJson = {
				SName:_temp.Name,
				SID:_temp.SightID,
				Ticket:_temp.Price,
				IMG:_temp.ImageSrc,
				Address:_temp.Address,
				Latitude:_temp.Latitude,
				Longitude:_temp.Longitude
			};
			if (!iPowDraw.isExist(sightJson))
			{
				//弹出层表单数据
				var _tempHtml = '<div class="TB_Form"><span><label>选择行程：</label>';
				_tempHtml += '<select name="selTravel" id="selTravel" class="selStyle">';
				var _daynum = parseInt(tripData.length) + 1;
				for (var j=1;j<=_daynum;j++)
				{
					if (j==_daynum)
						_tempHtml += '	<option value="'+j+'" selected="selected">第'+j+'天</option>';
					else
						_tempHtml += '	<option value="'+j+'">第'+j+'天</option>';
				}
				_tempHtml += '</select><a href="javascript:;" class="btnSubmit" id="btnSetPlan"></a></span>';
				_tempHtml += '</div>';
				//弹出图层
				$(_this.travelElem).TBwin({
					width:300,
					height:100,
					title:"行程安排",
					datahtml:_tempHtml,
					datatype:"html",
					isBG:false,
					callback:function(){
						$("#btnSetPlan").click(function(){
							var _selected = $("#selTravel option:selected").attr("value");
							_sightHtml = '<div class="infoContent" id="sight'+sightJson.SID+'">\
       										<a href="'+_temp.Url+'" class="aImg">\
           										<img src="'+_temp.ImageSrc+'" />\
       										</a>\
       										<div class="tourInfo">\
           										<h3><a href="'+_temp.Url+'" target="_blank">'+sightJson.SName+'</a>&nbsp;&nbsp;&nbsp;&nbsp;'+_temp.SightType+'</h3>\
           										<dl>\
               										<dt>\
                   										<span>￥<font class="fPrice">'+sightJson.Ticket+'</font>/门票</span>\
                   										<a href="'+_temp.Url+'" target="_blank" class="aLookMore">查看详细</a>\
                   										<a href="javascript:;" class="aDeleteSight" rel="sight'+sightJson.SID+'|'+_selected+'">移除行程</a>\
               										</dt>\
               										<dd class="dTitle">[<a href="'+obj.SightEntity.Url+'/pic1.shtml" title="更多图片" target="_blank">图片</a>] \
													[<a href="'+_temp.Url+'/video1.shtml" title="更多视频" target="_blank">视频</a>] \
													[<a href="'+_temp.Url+'/article1.shtml" title="更多攻略" target="_blank">攻略</a>] \
													[<a href="'+_temp.Url+'/guide.shtml" title="查看导游图" target="_blank">导游图</a>]</dd>\
               										<dd class="dSpecial">营业时间：'+_temp.ShopHours+'</dd>\
               										<dd class="dSpecial">最佳旅游时间：'+_temp.OpToTime+'</dd>\
               										<dd class="dSpecial">地址：'+_temp.Address+'</dd>\
           										</dl>\
       										</div>\
       									</div>';
							_this.toPlan(_selected,_sightHtml,sightJson,obj.CirSight,obj.CirHotel);
						}
					)}
				});
			}
			else
			{
				alert("已经存在此景区:)");
			}
		}
	},
	toPlan:function(day,html,json,cirsight,cirhotel){
		var _this = this;
			$("#TB_Windows").animate({
					top:136
				}, 100).animate({
					opacity: "toggle"
				},1000,function(){
					_this.isEdit = true;
					var cirSightListJson = cirsight;
					var cirHotelListJson = cirhotel;
					if (tripData[parseInt(day-1)]==undefined || tripData[parseInt(day-1)] == "undefined")
					{
						var _tempTripData = {
							DayID:day,
							TName:"",
							Sight:[json],
							Hotel:[],
							Traffic:[],
							DTotal:json.Ticket
						};
						tripData.push(_tempTripData);
						_this.cirSight.push(cirSightListJson);
						_this.cirHotel.push(cirHotelListJson);
						$("#tabDays").append('<a href="javascript:;" rel="'+day+'">第'+day+'天</a>');
						var _tourHtml = '<div class="tourContainer" id="tourContainer'+day+'">';
						_tourHtml += '<div class="tourTip">\
       									<h2>游玩景点</h2>\
										<em class="emDayNum" title="1">第'+day+'天</em>\
   									  </div>\
   										<div class="insetContainer" id="sightContainer'+day+'">';
						_tourHtml += html;
						_tourHtml += '	</div>';
						_tourHtml += '	<div class="tourTip">\
       										<h2>住宿酒店</h2>\
       										<em></em>\
   										</div><div class="insetContainer">请根据需要从周边酒店选择您满意的酒店！<br><br></div>';
						_tourHtml += '	<div class="tourTip">\
       										<h2>交通</h2>\
       										<em></em>\
   										</div><div class="insetContainer">正在建设中，敬请关注！<br><br></div>';
						_tourHtml += '</div>';
						_this.travelElem.append(_tourHtml);
						//行程天数按钮事件
						var _tabObj = _this.tabDays.find("a");
						_tabObj.unbind("click");
						$.each(_tabObj,function(index,tab){
							$(tab).click(function(){
								_this.tabClick(this,index);  
							})				
						});
						
					}
					else
					{
						if (parseInt(tripData[parseInt(day-1)].Sight.length)>1)
						{
							if(!confirm("您第"+day+"天行程景区数量超过2个了\r是否继续添加？"))
							{
								return false;
							}
						}
						tripData[parseInt(day-1)].Sight=tripData[parseInt(day-1)].Sight.concat(json);
						//计算当天费用
						tripData[parseInt(day-1)].DTotal = parseInt(tripData[parseInt(day-1)].DTotal) + parseInt(json.Ticket);
						_this.travelElem.find(".tourContainer:eq("+parseInt(day-1)+") .insetContainer:eq(0)").prepend(html);
						
					}
					_this.tabDays.find("a:eq("+parseInt(day-1)+")").trigger("click");
					//绑定景区删除
					$("#sight"+json.SID+" .aDeleteSight").click(function(){
						_this.delSight(this);												  
					});
					$("#sightAllInfo").append("+"+json.SName);
					$("#tourConst").text(parseInt($("#tourConst").text())+parseInt(json.Ticket));
				
			});
		
	},
	addHotel:function(obj){
		var _this = this;
		var _hotelHtml = '';
		if (obj.Type == "OK")
		{
			var _temp  = JSON.parse(obj.SightEntity);
			var hoteljson = {
				HotelID:_temp.HotelID,
				HName: _temp.Name,
				Latitude:_temp.Latitude,
				Longitude:_temp.Longitude,
				HPrice:parseInt(_temp.Price),
				ImageSrc: _temp.ImageSrc,
				Address: _temp.Address,
				CommCount: _temp.CommCount,
				PicCount: _temp.PicCount,
				HotelType: _temp.HotelType,
				DomID: 'hotel'+_temp.HotelID+''
			};
			if (tripData.length>1)
			{
				//弹出层表单数据
				var _tempHtml = '<div class="TB_Form"><span><label>选择行程：</label>';
				_tempHtml += '<select name="selTravelHotel" id="selTravelHotel" class="selStyle">';
				var _daynum = parseInt(tripData.length);
				for (var j=1;j<=_daynum;j++)
				{
					if (j==_daynum)
						_tempHtml += '	<option value="'+j+'" selected="selected">第'+j+'天</option>';
					else
						_tempHtml += '	<option value="'+j+'">第'+j+'天</option>';
				}
				_tempHtml += '</select><a href="javascript:;" class="btnSubmit" id="btnSetHotel"></a></span></div>';
				//弹出图层
				$(_this.travelElem).TBwin({
					width:300,
					height:100,
					title:"行程安排",
					datahtml:_tempHtml,
					datatype:"html",
					isBG:false,
					callback:function(){
						$("#btnSetHotel").click(function(){
							var _selected = $("#selTravelHotel option:selected").attr("value");
							_hotelHtml = '<div class="infoContent" style=" background-color:#EAEAEA;" id="hotel'+hoteljson.HotelID+'">\
							<a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" class="aImg" target="_blank">\
								<img src="'+hoteljson.ImageSrc+'" />\
							</a>\
							<div class="tourInfo">\
								<h3><a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" target="_blank">'+hoteljson.HName+'</a>&nbsp;&nbsp;&nbsp;&nbsp;'+hoteljson.HotelType+'</h3>\
								<dl>\
									<dt>\
										<span>￥<font class="fPrice">'+hoteljson.HPrice+'</font>/起</span>\
										<a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" target="_blank" class="aLookMore">查看详细</a>\
										<a href="javascript:;" class="aDeleteHotel" rel="hotel'+hoteljson.HotelID+'|'+_selected+'">移除行程</a>\
									</dt>\
									<dd class="dContent">地址：'+hoteljson.Address+'</dd>\
								</dl>\
							</div>\
						</div>';
							_this.toPlanHotel(_selected,_hotelHtml,hoteljson);
						}
					)}
				});
			}
			else
			{
				var _tempPrice = _this.travelElem.find(".tourContainer:eq(0) .insetContainer:eq(1) .fPrice").text();
				_hotelHtml = '<div class="infoContent" style=" background-color:#EAEAEA;" id="hotel'+hoteljson.HotelID+'">\
							<a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" class="aImg" target="_blank">\
								<img src="'+hoteljson.ImageSrc+'" />\
							</a>\
							<div class="tourInfo">\
								<h3><a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" target="_blank">'+hoteljson.HName+'</a>&nbsp;&nbsp;&nbsp;&nbsp;'+hoteljson.HotelType+'</h3>\
								<dl>\
									<dt>\
										<span>￥<font class="fPrice">'+hoteljson.HPrice+'</font>/起</span>\
										<a href="http://hotel.ipow.cn/'+hoteljson.HotelID+'.shtml" target="_blank" class="aLookMore">查看详细</a>\
										<a href="javascript:;" class="aDeleteHotel" rel="hotel'+hoteljson.HotelID+'|1">移除行程</a>\
									</dt>\
									<dd class="dContent">地址：'+hoteljson.Address+'</dd>\
								</dl>\
							</div>\
						</div>';
				if (_tempPrice == "")
					_tempPrice = 0;
				_this.travelElem.find(".tourContainer:eq(0) .insetContainer:eq(1)").html(_hotelHtml);
				//绑定景区删除
				$("#hotel"+hoteljson.HotelID+" .aDeleteHotel").click(function(){
					_this.delHotel(this);												  
				});
				$("#tourConst").text(parseInt($("#tourConst").text())+parseInt(hoteljson.HPrice)-parseInt(_tempPrice));
				//计算当天费用
				tripData[0].DTotal = parseInt(tripData[0].DTotal) + parseInt(hoteljson.HPrice)-parseInt(_tempPrice);
			}
		}
	},
	toPlanHotel:function(day,html,json){
		var _this = this;
		$("#TB_Windows").animate({
				top:136
			}, 100).animate({
				opacity: "toggle"
			},1000,function(){
				_this.isEdit = true;
				tripData[parseInt(day-1)].Hotel=json;
				//计算当天费用
				tripData[parseInt(day-1)].DTotal = parseInt(tripData[parseInt(day-1)].DTotal) + parseInt(json.HPrice);
				var _tempPrice = _this.travelElem.find(".tourContainer:eq("+parseInt(day-1)+") .insetContainer:eq(1) .fPrice").text();
				if (_tempPrice == "")
					_tempPrice = 0;
				_this.travelElem.find(".tourContainer:eq("+parseInt(day-1)+") .insetContainer:eq(1)").html(html);
				_this.tabDays.find("a:eq("+parseInt(day-1)+")").trigger("click");
				//绑定景区删除
				$("#hotel"+json.HotelID+" .aDeleteHotel").click(function(){
					_this.delHotel(this);												  
				});
				$("#tourConst").text(parseInt($("#tourConst").text())+parseInt(json.HPrice)-parseInt(_tempPrice));
		});
	},
	delSight:function(obj){
		var _this = this;
		var _delInfo = $(obj).attr("rel");
		_delInfo = _delInfo.split("|");
		var _demo = _delInfo[0];
		var _num = parseInt(_delInfo[1]);
		var _tourDiv = "tourContainer" + _num.toString();
		var _day = $("div.tourContainer").index($("#"+_tourDiv));
		if (tripData.length == 1 && tripData[_day].Sight.length == 1)
		{
			alert("行程游玩景区不能为空！）：");
			return false;
		}
		$("#" + _demo).fadeOut(500,function(){
			_this.isEdit = true;
			var _sightID = _demo.replace("sight","");
			var _ticket = 0;
			var _const = parseInt($("#tourConst").text());
			$.each(tripData[_day].Sight,function(index,sJson){
				if (sJson.SID == parseInt(_sightID))
				{
					_ticket = tripData[_day].Sight[index].Ticket;
					tripData[_day].Sight.splice(index,1);
					$("#sightAllInfo").text($("#sightAllInfo").text().replace(sJson.SName,""));
					return false;
				}
			});
			if((tripData[_day].Sight==""||tripData[_day].Sight.length==undefined) && tripData[_day].Hotel == "")
			{
				tripData.splice(_day,1);
				_this.cirHotel.splice(_day,1);
				_this.cirSight.splice(_day,1);
				$.each(_this.travelElem.find(".tourContainer:gt("+_day+") .tourTip .emDayNum"),function(index,dom){
					var _tempNum = parseInt($(dom).attr("title"));
					_tempNum = parseInt(_tempNum-1);
					$(dom).attr("title",_tempNum);
					$(dom).text("第"+_tempNum+"天");
				});
				$("#"+_tourDiv).remove();
				_this.reloadTab(_day);
			}
			else
			{
				tripData[_day].DTotal = parseInt(tripData[_day].DTotal)-parseInt(_ticket);
			}
			$("#tourConst").text(_const - parseInt(_ticket));
			$(this).remove();
		});
	},
	delHotel:function(obj){
		var _this = this;
		var _delInfo = $(obj).attr("rel");
		_delInfo = _delInfo.split("|");
		var _demo = _delInfo[0];
		var _num = parseInt(_delInfo[1]);
		var _tourDiv = "tourContainer" + _num.toString();
		var _day = $("div.tourContainer").index($("#"+_tourDiv));
		var ddd = tripData;
		$("#" + _demo).fadeOut(500,function(){
			_this.isEdit = true;
			var _hotelID = _demo.replace("hotel","");
			var _hprice = parseInt(tripData[_day].Hotel.HPrice);
			var _const = parseInt($("#tourConst").text())-parseInt(_hprice);
			tripData[_day].Hotel = "";
			if(tripData[_day].Sight=="" && tripData[_day].Hotel == "")
			{
				tripData.splice(_day,1);
				_this.cirHotel.splice(_day,1);
				_this.cirSight.splice(_day,1);
				$.each(_this.travelElem.find(".tourContainer:gt("+_day+") .tourTip .emDayNum"),function(index,dom){
					var _tempNum = parseInt($(dom).attr("title"));
					_tempNum = parseInt(_tempNum-1);
					$(dom).attr("title",_tempNum);
					$(dom).text("第"+_tempNum+"天");
				});
				$("#"+_tourDiv).remove();
				_this.reloadTab(_day);
			}
			else
			{
				tripData[_day].DTotal = parseInt(tripData[_day].DTotal) - _hprice;
			}
			$(this).parent().html("请根据需要从周边酒店选择您满意的酒店！<br><br>");
			//$(this).remove();
			$("#tourConst").text(_const);
		});
	},
	reloadTab:function(day){    //重新加载TAB
		var _this = this;
		$.each(_this.tabDays.find("a:gt("+day+")"),function(index,tab){
			var _tempday = parseInt($(tab).attr("rel"));
			$(tab).text("第"+parseInt(_tempday-1)+"天");
			//_this.travelElem.find(".tourContainer:eq("+index+") .tourTip .emDayNum").text("第"+parseInt(_tempday-1)+"天");
		});
		
		_this.tabDays.find("a:eq("+day+")").remove();
		var _tabObj = _this.tabDays.find("a");
		_tabObj.unbind("click");
		$.each(_tabObj,function(index,tab){
			$(tab).click(function(){
				_this.tabClick(this,index);
			})				
		});
		_this.tabDays.find("a").eq(0).trigger("click");
	},
	save:function(obj){
		if (this.isEdit)
		{
			if (iPowDraw == null)
				iPowDraw = new DrawTravel(null);
			iPowDraw.save(obj,"edit");
		}
		else
		{
			alert("请先修改线路再保存:)")
		}
	},
	savesuccess:function(obj){    //数据保存成功
		if (obj.Type == "OK")
		{
			var _this = this;
			$("#TB_Windows").animate({
					top:136
				}, 100).animate({
					opacity: "toggle"
				},1000,function(){
					tripData = [];
					$("#TB_Windows").hide();
					window.location.href = "http://192.168.1.65:300" + obj.Path;
				}
			);
		}
		
	},
	transpond:function(obj){   //转发
		var thisHttp = document.location;
		var tripTitle = document.title;
		var _tempHtml = '<div class="TB_Form"><span><label>名　称：</label><input id="EmailTitle" value="'+tripTitle+'" type="text" class="txtInput"/><em>*</em></span>';
		_tempHtml += '<span><label>邮　箱：</label><input id="Email" type="text" class="txtInput"/><em>*</em></span>';
		_tempHtml += '<span><label>&nbsp;</label><a href="javascript:;" class="btnSubmit" id="btnSubmit"></a></span></div>';
		$(obj).TBwin({
			width:350,
			height:140,
			title:"信息转发",
			datahtml:_tempHtml,
			datatype:"html",
			isBG:false,
			callback:function(){
				$("#btnSubmit").click(function(){
					var _email = $("#Email").val();
					if (_email == "")
					{
						alert("请输入您的邮箱:)");
						$("#Email").focus();
						return false;
					}
					
											   
				});
			}
		});
		
	},
	doprint:function(obj){  //打印行程
		var printHtml = '',daynum=0,tripCost=0;
		$.each(tripData,function(index,tripJson){
			//每一天的行程内容
			printHtml += '<div class="printContent">';
			printHtml += '	<div class="printContentL"><span>第'+tripJson.DayID+'天</span></div>';
			printHtml += '	<div class="printContentR">';
			printHtml += '		<div class="printRTitle"><h2>游玩景点：</h2></div>';
			//游玩景点
			$.each(tripJson.Sight,function(sindex,sightJson){
				printHtml += '		<div class="printInfos">\
					<span class="number">'+parseInt(sindex+1)+'</span>\
					<span class="sight">\
						<h3>'+sightJson.SName+'</h3><em>￥'+sightJson.Ticket+'</em>\
						<h4>'+sightJson.Address+'</h4>\
					</span>\
				</div>'; 
			});
			printHtml += '		<div class="printRTitle"><h2>住宿酒店：</h2></div>';
			if(tripJson.Hotel!="")
			{
				printHtml += '	<div class="printInfos">\
									<span class="hotel">\
										<h3>'+tripJson.Hotel.HName+'</h3><em>￥'+tripJson.Hotel.HPrice+'</em>\
										<h4>'+tripJson.Hotel.Address+'</h4>\
									</span>\
								</div>';
			}
			printHtml += '	</div>';
			
			printHtml += '	<div class="clear"></div>';
			printHtml += '	</div>';
			daynum = tripJson.TName;
			tripCost += parseInt(tripJson.DTotal);
		});
		printHtml += '	<div style="float:left;width:100%; height:30px; text-align:center;"><a href="javascript:;" onclick="window.print();">打印</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:;" onclick="window.close();">关闭</a></div>';
		printHtml = '<div class="printTitle">\
    			<h1>'+$("#TourTitle").text()+'</h1>\
        		<em></em>\
        		<span class="daynum">'+tripData.length+'日游</span>\
        		<em></em>\
        		<span class="cost">总费用：<b>￥'+tripCost+'</b></span>\
    		</div>'+printHtml;
		document.domain = "ipow.cn";
		var OpenWindow=window.open("", "newwin", "height=540, width=880,toolbar=no,scrollbars=yes,menubar=no");
		//写成一行
		OpenWindow.document.write("<title>"+$("#TourTitle").text()+"打印</title>")
		OpenWindow.document.write('<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />');
		OpenWindow.document.write('<link type="text/css" rel="stylesheet" href="/style/tour.css" />');
		OpenWindow.document.write('<style type="text/css">body{margin:0px;padding:0px;overflow-x:hidden}</style>');
		OpenWindow.document.write("<body>")
		OpenWindow.document.write(printHtml)
		OpenWindow.document.write("</body>")
		OpenWindow.document.write("</HTML>")
		OpenWindow.document.close(); 
		return false;
	},
	paging:function(daynum,pagemax,pagecurrent,sightjson,cirjson,type){   //酒店分页
		var tempThis = this,_html = "";
		var cirMap = [];
		//cirjson = sightMap
		$("#CirInfoPage").html("").hide();
		if(cirjson == "")
		{
			$("#cirInfoList").html("<li>暂无周边信息！</li>")
		}
		else
		{
			if (cirjson[parseInt(daynum)] == "")
			{
				$("#cirInfoList").html("<li>暂无周边信息！</li>")
			}
			else
			{
				var startindex = endindex=0;
				var circount = cirjson[parseInt(daynum)].length;
				var allPage = Math.ceil(circount/pagemax);
				
				if (allPage>=pagecurrent)
				{
					switch(pagecurrent){
						case 1:
							$("#CirInfoPage").html('<a href="javascript:;" id="nextHotelPage">下一页</a>');
							$("#nextHotelPage").click(function(){
								tempThis.paging(daynum,pagemax,parseInt(pagecurrent+1),sightjson,cirjson,type)						   
							});
							break;
						case allPage:
							$("#CirInfoPage").html('<a href="javascript:;" id="prevHotelPage">上一页</a>');
							$("#prevHotelPage").click(function(){
								tempThis.paging(daynum,pagemax,parseInt(pagecurrent-1),sightjson,cirjson,type)						   
							});
							break;
						default:
							$("#CirInfoPage").html('<a href="javascript:;" id="nextHotelPage">下一页</a><a href="javascript:;" id="prevHotelPage">上一页</a>');
							$("#nextHotelPage").click(function(){
								tempThis.paging(daynum,pagemax,parseInt(pagecurrent+1),sightjson,cirjson,type)						   
							});
							$("#prevHotelPage").click(function(){
								tempThis.paging(daynum,pagemax,parseInt(pagecurrent-1),sightjson,cirjson,type)						   
							});
							break;
					};
					startindex = (pagecurrent-1)*pagemax;
					endindex = pagecurrent*pagemax;
					if (endindex>circount)
						endindex = circount;
					$("#cirInfoList").html("");
					$.each(cirjson[parseInt(daynum)].slice(startindex,endindex),function(index,h){
						var hoteljson = {};
						switch(type)
						{
							case "Sight":
								  _html += '<li id="hCirSight'+index+'"><a href="'+h.Url+'" rel="sight" title="'+h.Name+'"><img src="/images/icon/htop'+parseInt(index+1)+'.jpg" align="absmiddle" border="0"/><span class="title">'+h.Name+'</span><em>￥'+h.Price+'</em></a><span class="tourAddInfo" rel="'+h.SightID+'|sight"></span></li>'
								  hoteljson = {
									Name: h.Name,
									Url: h.Url,
									Type: type,
									Latitude:h.Latitude,
									Longitude:h.Longitude,
									Price:h.Price,
									ImageSrc: h.ImageSrc,
									Address: h.Address,
									CommCount: h.CommCount,
									PicCount: h.PicCount,
									SightType: h.SightType,
									DomID: 'hCirSight'+index+'',
									OrderID: parseInt(index+1)
								};
								break;
							case "Hotel":
								_html += '<li id="hCirHotel'+index+'"><a href="'+h.Url+'" rel="hotel" title="'+h.Name+'"><img src="/images/icon/htop'+parseInt(index+1)+'.jpg" align="absmiddle" border="0"/><span class="title">'+h.Name+'</span><em>￥'+h.Price+'</em></a><span class="tourAddInfo" rel="'+h.HotelID+'|hotel"></span></li>'
								hoteljson = {
									Name: h.Name,
									Url: h.Url,
									Type: type,
									Latitude:h.Latitude,
									Longitude:h.Longitude,
									Price:h.Price,
									ImageSrc: h.ImageSrc,
									Address: h.Address,
									CommCount: h.CommCount,
									PicCount: h.PicCount,
									HotelType: h.HotelType,
									DomID: 'hCirHotel'+index+'',
									OrderID: parseInt(index+1),
									markerPic:""
								};
								break;
							case "Repast":
								_html += '';
								break;
							default:
								break;
						
						}
						cirMap.push(hoteljson);
					});
					$("#cirInfoList").html(_html)
					$("#CirInfoPage").show();
					$("#cirInfoList .tourAddInfo").unbind("click");
					$("#cirInfoList .tourAddInfo").click(function(){
						var _tempString = $(this).attr("rel").split("|");
						var _tempID = _tempString[0];
						var _tempType = _tempString[1];
						switch(_tempType){
							case "sight":
								jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/SightHandler.ashx?Type=GetSight&SightID="+_tempID+"&CallBack=iPowEdit.addSight&temp="+Math.random());
								break;
							case "hotel":
								jQuery.getScript(iPowApi + "IpowAPI/Hotel/Requset/HotelHandler.ashx?Type=GetHotel&HotelID="+_tempID+"&CallBack=iPowEdit.addHotel&temp="+Math.random());
								break;
							default:
								break;
							
						}
					});
					cirMap = cirMap.concat(sightjson);
					mapinitialize(cirMap, 'gMap', 'jxMapTipPanel',false);
				}
			}
		}
	}
	
}


jQuery.fn.doGallery = function(settings){
	  settings = jQuery.extend({
	  itemsPerPage : 2,
	  animationSpeed : 'normal'
  }, settings);
	return this.each(function(){
	  var currentPage = 1;
	  var pageCount = 0;
	  var animated = false;
	  var $gallery = $(this);
	  var prettyGalleryPrevious = function(caller) {
			currentPage--;
			if(animated || $(caller).hasClass('disabled')) return;
			animated = true;
			$gallery.find('a:gt('+(currentPage * settings.itemsPerPage-settings.itemsPerPage-1)+')').each(function(i){
				jQuery(this).show();
				animated = false;
			});
			_displayPaging();
		};
		
		var prettyGalleryNext = function(caller) {
			if(animated || $(caller).hasClass('disabled')) return;
			animated = true;
			$gallery.find('a:lt('+(currentPage * settings.itemsPerPage)+')').each(function(i){
				jQuery(this).hide();
				animated = false;
			});
			currentPage++;
			_displayPaging();
		};
		
		var _applyNav = function()
		{
			jQuery('#aPrev').bind('click',function(){
				prettyGalleryPrevious(this);
				return false;
			});
			jQuery('#aNext').bind('click',function(){
				prettyGalleryNext(this);
				return false;
			});
		};
		var _displayPaging = function() {
			if(pageCount==1)
			{
				jQuery('#aPrev').hide();
				jQuery('#aNext').hide();
			}
			else if(currentPage == 1){
				jQuery('#aPrev').hide();
				jQuery('#aNext').show();
			} else if(currentPage == pageCount) 
			{
				jQuery('#aPrev').show();
				jQuery('#aNext').hide();
			}
			else if (currentPage<pageCount)
			{
				jQuery('#aPrev').show();
				jQuery('#aNext').show();
				
			}
		};
	  
	  	if(jQuery(this).find('a').size() >= settings.itemsPerPage) {		
			pageCount = Math.ceil(jQuery(this).find('a').size() / settings.itemsPerPage);
			_applyNav();
			_displayPaging(this);
			currentPage = 1;
		};
	});
}
jQuery.fn.doTab=function(settings)
{
	settings = jQuery.extend({
	  itemsPerPage:5,
	  tabContent:'',
	  fun : ''
  }, settings);
	return this.each(function(){
		var currentPage = 1;
		var pageCount = 0;
		var animated = false;
		var $gallery = $(this);
		var _showList = function(rel){
			$("#"+settings.tabContent).find("a").hide();
			$("#"+settings.tabContent).contents().not("[rel!="+rel+"]").show();
		}
		$gallery.find("a").click(function(i){
			$gallery.find("li").removeClass();
			$("#" + this.id).parent().addClass("current");
			_showList(this.rel);				 
		});
	
	});
}

jQuery.fn.TBwin = function(parameters)
{
	parameters = jQuery.extend({
		width:600,
		height:450,
		title:"",
		datahtml:"",
		datatype:"",
		isBG:true,
		url:"",
		callback:null
	},parameters);
	return this.each(function(){
		var $win = $(this); 
		var $tbPosition;
		var _initwin = function(obj)
		{
			if (parameters.isBG)
			{
				var _winHtml = '<div id="TB_WinBg"></div>';
				$tbPosition = getAllPosition(obj);
				$("#TB_WinBg").remove();
				$("body").append(_winHtml);
				var _height = document.body.scrollHeight > document.body.offsetHeight ? document.body.scrollHeight : document.body.offsetHeight;
				if (typeof document.body.style.maxHeight === "undefined")
				{
					$("body","html").css({height: "100%", width: "100%"});   
					$("html").css("overflow","hidden"); 
				}	
				else
				{
					$("#TB_WinBg").css("height",""+_height+"px"); 
				}
				//$("#TB_WinBg").css({height:$tbPosition.offHeight,width:$tbPosition.offWidth+18,top:$tbPosition.scrTop});
			}
			$("#TB_Windows").remove();
			_initmsg(obj);
			/*$(window).resize(function(){
				if ($("#TB_Windows").is(":visible"))
					_resize(obj);
			}); */
			$(window).scroll(function(){
				if ($("#TB_Windows").is(":visible"))
					_scroll(obj);
			});
		}
		var _initmsg = function(obj)
		{
			var _winHtml = '<div id="TB_Windows"><div id="TB_WinTitle"><h3 class="title">'+parameters.title+'</h3><a href="javascript:;" id="TB_Close" title="关闭" class="close"></a></div><div id="TB_WinContent"></div></div>';
			$("body").append(_winHtml);
			var tb_winid = "TB_Windows";
			$("#TB_Windows").css({"width":parameters.width,"height":parameters.height});
			$("#TB_WinContent").css({"height":parameters.height-40});
			
			$tbPosition = getAllPosition(obj);
			var scrTop = parseInt($tbPosition.scrTop);
			var winLeft = parseInt(parseInt($tbPosition.offWidth - parameters.width)/2);
			var winHeight = parameters.height;
			$("#"+tb_winid).css({"left":winLeft,"top":-winHeight});
			var winTop = parseInt(($tbPosition.offHeight-parameters.height)/2)+parseInt($tbPosition.scrTop);
			$("#"+tb_winid).animate({
					opacity:"show",
					top:winTop+50
				}, 100).animate({
					top:winTop
				}, 400,function(){
					switch(parameters.datatype){
						case "html":
							$("#TB_WinContent").html(parameters.datahtml);
							break;
						default:
							break;
					};
					$("#TB_Windows #TB_Close").bind("click",function(){_close()});
					if (jQuery.isFunction(parameters.callback))
						parameters.callback.call(this);
					
			});
		};
		//关闭图层
		var _close = function(){
			$("#TB_Windows").animate({
					top:150
				}, 100).animate({
					opacity: "toggle"
				},1000,function(){
					$("#TB_WinBg").remove();
					$("#TB_Windows").remove();
					if (typeof document.body.style.maxHeight == "undefined") 
					{
						$("body","html").css({height: "auto", width: "auto"});
						$("html").css("overflow","");
					}
					$(window).unbind("scroll");
					$(window).unbind("resize");
				});
		};
		//重设图层位置
		var _resize = function(obj){
			var $newPosition = getAllPosition(obj);
			var scrTop = parseInt($newPosition.scrTop);
			var winLeft = parseInt(parseInt($newPosition.offWidth - parameters.width)/2);
			var winTop = parseInt(($newPosition.offHeight-parameters.height)/2)+parseInt($newPosition.scrTop);
			$("#TB_Windows").css({"left":winLeft,"top":winTop});
			
		};
		var _scroll = function(obj){
			var $newPosition = getAllPosition(obj);
			var scrTop = parseInt($newPosition.scrTop);
			var winTop = parseInt(($newPosition.offHeight-parameters.height)/2)+parseInt($newPosition.scrTop);
			$("#TB_Windows").css({"top":winTop});
		}
		_initwin(this);	
	});
	
	
}



//获取位置
function getAllPosition(obj){
	var displayPosition=[];
	if (obj!=undefined)
	{
		var objPosition = $(obj).offset();
		displayPosition.offLeft=objPosition.left;
		displayPosition.offTop = objPosition.top;
	}
	displayPosition.offWidth = document.documentElement.clientWidth;
	displayPosition.offHeight = document.documentElement.clientHeight;
	var scrollPos,scrollLeft,_offsetLeft;
	if (typeof window.pageYOffset != 'undefined') {
		scrollPos = window.pageYOffset;
		scrollLeft = 0;
	}
	else if (typeof document.compatMode != 'undefined' && document.compatMode != 'BackCompat') {
		scrollPos = document.documentElement.scrollTop;
		scrollLeft = document.documentElement.scrollLeft;
		
	}
	else if (typeof document.body != 'undefined') {
		scrollPos = document.body.scrollTop;
		scrollLeft = document.body.scrollLeft;
	}
	if (displayPosition.offWidth>1003)
		_offsetLeft = parseFloat(displayPosition.offWidth - 1003)/2;
	else
		_offsetLeft = 0;
	displayPosition.scrTop = scrollPos;
	displayPosition.scrLeft = scrollLeft;
	displayPosition.offsetLeft = _offsetLeft;
	return displayPosition;
}

function getCookie(cookiename)
{
	var CookieValue = "";
	//获取cookie字符串
	var strCookie=document.cookie;
	if (strCookie != "")
	{
		//将多cookie切割为多个名/值对
		var arrCookie=strCookie.split("; ");
		//遍历cookie数组，处理每个cookie对
		for(var i=0;i<arrCookie.length;i++)
		{
         	var arr=arrCookie[i].split("=");
         	//找到对应名称的cookie，并返回它的值
         	if(cookiename==arr[0])
		 	{
              	CookieValue=arr[1];
              	break;
         	}
		}
	}
	if (CookieValue != "undefined")
		return CookieValue;
	else
		return "";
}

//排序
var listMap = this.listMap = new function(){
	this.listMapData = [];
	this.tempMapData = [];
	this.showMapData = [];
	this.filters = {Const:[],DayNum:[],Live:[]};
	this.orders = {};
	this.init = function(obj,filters){
		this.listMapData = obj;
		this.tempMapData = obj;
		this.filters = filters;
		this.filterManage();
	};
	this.filterPriceFace = function(field, _min, _max){  //数据范围筛选
		var index = 1;
		var tempMap = [];
		var _tempObj = this.tempMapData
		for (var i = 0; i < _tempObj.length; i++) {
			var v = parseInt(_tempObj[i][""+field+""]);
			if (_max == "max")
			{
				if (v >= parseInt(_min))
				{
					tempMap.push(_tempObj[i]);
				}
			}
			else
			{
				if (v >= parseInt(_min) && v <= parseInt(_max))
				{
					tempMap.push(_tempObj[i]);
				}
			}
		}
		this.showMapData = this.showMapData.concat(tempMap);
		iPowDraw.sPage(this.showMapData,1);
    };
	this.orderFace = function(field,order){   //数据排序
		order = parseInt(order);
		var tempObj = this.showMapData;
		var exchange;
		switch (order) {
			case 0:
				for(var i=0; i<tempObj.length; i++) {
   					exchange = false;
   					for(var j=tempObj.length-2; j>=i; j--) {
    					if((parseInt(tempObj[j+1]["" + field + ""])) < parseInt(tempObj[j]["" + field + ""])) {
     						var temp = tempObj[j+1];
     						tempObj[j+1] = tempObj[j];
     						tempObj[j] = temp;
     						exchange = true;
    					}
   					}
   					if(!exchange) break;
  				}
				break;
			case 1:
				for(var i=0; i<tempObj.length; i++) {
   					exchange = false;
   					for(var j=tempObj.length-2; j>=i; j--) {
    					if(parseInt(tempObj[j+1]["" + field + ""]) > parseInt(tempObj[j]["" + field + ""])) {
     						var temp = tempObj[j+1];
     						tempObj[j+1] = tempObj[j];
     						tempObj[j] = temp;
     						exchange = true;
    					}
   					}
   					if(!exchange) break;
  				}
				break;
			default:
				break;
		};
		this.showResult(tempObj);
	}
	this.trackFilter = function(filter,arguments){
		var _value;
		switch(filter){
			case "Const": case "DayNum":
				if ($(arguments).attr("checked"))
				{
					_value = $(arguments).val().split("-");
					this.filters[""+filter+""].push(_value);
				}
				else
				{
					_value = $(arguments).val().split("-");
					var _index;
					$.each(this.filters[""+filter+""],function(index,_arr){
						if(_arr.sort().toString()==_value.sort().toString())
						{
							_index = index;
							return false;
						}
					})
					this.filters[""+filter+""].splice(_index,1);
				}
				break;
			default:
				break;
		};
		this.filterManage();
    };
	this.trackOrder = function(arguments){
		if ($(arguments).attr("checked"))
		{
			var _value = $(arguments).val().split(",");
			this.orderFace(_value[0],_value[1]);
		}
	};
	this.filterManage = function(){
			//this.showMapData = [];
			var _this = this;
			if (this.filters.Const!="")
			{
				$.map(this.filters.Const,function(_arrConst){
					_this.filterPriceFace("Const",_arrConst[0],_arrConst[1]);		   
				});
			}
			else
			{
				this.showMapData=this.tempMapData;
			}
			if (this.filters.DayNum!="")
			{
				if (this.filters.Const!="" || this.filters.Live!="")
				{
					this.tempMapData = this.showMapData;
					this.showMapData = [];
				}
				else
				{
					this.showMapData = [];
				}
				$.map(this.filters.DayNum,function(_arrNum){
					_this.filterPriceFace("DayNum",_arrNum[0],_arrNum[1]);					   
				});
			}
			//alert(this.filters.Live)
		/*switch(filter)
		{
			case "Const":case "DayNum":
				if (this.filters.DayNum=="")
				{
					this.tempMapData = this.listMapData;
					this.showMapData = [];
				}
				else
				{
					this.tempMapData = this.showMapData;
					this.showMapData = [];
				}
				
				var _this = this;
				$.map(this.filters[""+filter+""],function(_arr){
					_this.filterPriceFace(filter,_arr[0],_arr[1]);	  
				});
				break;
			default:
				break;
		}*/
	};
	this.showResult=function(obj)
	{
		$("#sTripCount").html(this.showMapData.length);
		if (this.showMapData.length==0)
		{
			var _keyword = $("#fKeyword").text();
			$("#ResultList").html('<p>暂无满足条件的线路<br>请修改您的搜索条件或者<a href="http://jq.ipow.cn/search/?q='+encodeURIComponent(_keyword)+'" target="_blank">制定线路</a></p>')
		}
		else
		{
			iPowDraw.sPage(obj,1);
		}
	}
}
function checkNumber(e)
{
	var key = window.event ? e.keyCode : e.which;
	var keychar = String.fromCharCode(key);
	reg = /\d/;
	var result = reg.test(keychar);
	if(!result)
	{
		alert("只能输入数字:)");
		return false;
	}
	else
	{
		return true;
	}
} 

//校验邮箱
function isEmail(s){
    var patrn = /^[a-zA-Z0-9_\-]{1,}@[a-zA-Z0-9_\-]{1,}\.[a-zA-Z0-9_\-.]{1,}$/;
    if (!patrn.exec(s)) {
        return false;
    }
    return true;
}

