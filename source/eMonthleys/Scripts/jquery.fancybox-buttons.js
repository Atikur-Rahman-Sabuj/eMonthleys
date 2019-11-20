 /*!
 * Buttons helper for fancyBox
 * version: 1.0.5 (Mon, 15 Oct 2012)
 * @requires fancyBox v2.0 or later
 *
 * Usage:
 *     $(".fancybox").fancybox({
 *         helpers : {
 *             buttons: {
 *                 position : 'top'
 *             }
 *         }
 *     });
 *
 */
(function ($) {
	//Shortcut for fancyBox object
	var F = $.fancybox;

	//Add helper object
	F.helpers.buttons = {
		defaults : {
			skipSingle : false, // disables if gallery contains single image
			position   : 'top', // 'top' or 'bottom'
			tpl        : '<div id="fancybox-buttons"><ul><li><a class="BtnPrev" title="Previous" href="javascript:;"></a></li><li><a class="BtnPlay" title="Start slideshow" href="javascript:;"></a></li><li><a class="BtnNext" title="Next" href="javascript:;"></a></li><li><a class="BtnToggle" title="Toggle size" href="javascript:;"></a></li><li><a class="BtnClose" title="Close" href="javascript:;"></a></li></ul></div>'
		},

		list : null,
		buttons: null,

		beforeLoad: function (opts, obj) {
			//Remove self if gallery do not have at least two items

			if (opts.skipSingle && obj.group.length < 2) {
				obj.helpers.buttons = false;
				obj.closeBtn = true;

				return;
			}

			//Increase top margin to give space for buttons
			obj.margin[ opts.position === 'bottom' ? 2 : 0 ] += 30;
		},

		onPlayStart: function () {
			if (this.buttons) {
				this.buttons.play.attr('title', 'Pause slideshow').addClass('BtnPlayOn');
			}
		},

		onPlayEnd: function () {
			if (this.buttons) {
				this.buttons.play.attr('title', 'Start slideshow').removeClass('BtnPlayOn');
			}
		},

		afterShow: function (opts, obj) {
			var buttons = this.buttons;

			if (!buttons) {
				this.list = $(opts.tpl).addClass(opts.position).appendTo('body');

				buttons = {
					prev   : this.list.find('.BtnPrev').click( F.prev ),
					next   : this.list.find('.BtnNext').click( F.next ),
					play   : this.list.find('.BtnPlay').click( F.play ),
					toggle : this.list.find('.BtnToggle').click( F.toggle ),
					close  : this.list.find('.BtnClose').click( F.close )
				};
			}

			//Prev
			if (obj.index > 0 || obj.loop) {
				buttons.prev.removeClass('BtnDisabled');
			} else {
				buttons.prev.addClass('BtnDisabled');
			}

			//Next / Play
			if (obj.loop || obj.index < obj.group.length - 1) {
				buttons.next.removeClass('BtnDisabled');
				buttons.play.removeClass('BtnDisabled');

			} else {
				buttons.next.addClass('BtnDisabled');
				buttons.play.addClass('BtnDisabled');
			}

			this.buttons = buttons;

			this.onUpdate(opts, obj);
		},

		onUpdate: function (opts, obj) {
			var toggle;

			if (!this.buttons) {
				return;
			}

			toggle = this.buttons.toggle.removeClass('BtnDisabled BtnToggleOn');

			//Size toggle button
			if (obj.canShrink) {
				toggle.addClass('BtnToggleOn');

			} else if (!obj.canExpand) {
				toggle.addClass('BtnDisabled');
			}
		},

		beforeClose: function () {
			if (this.list) {
				this.list.remove();
			}

			this.list    = null;
			this.buttons = null;
		}
	};

}(jQuery));
