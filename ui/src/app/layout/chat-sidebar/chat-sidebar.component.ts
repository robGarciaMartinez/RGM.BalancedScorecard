import { Component, OnInit, ElementRef } from '@angular/core';
import { ChatService } from './chat.service';
declare let jQuery: any;
declare let Hammer: any;

@Component({
  selector: '[chat-sidebar]',
  templateUrl: './chat-sidebar.template.html'
})
export class ChatSidebar implements OnInit {
  conversations: ChatService;
  newMessage: string = '';
  activeConversation: any;
  chatMessageOpened: boolean = false;
  $el: any;
  searchText: string = '';

  constructor(el: ElementRef) {
    this.conversations = new ChatService();

    this.$el = jQuery(el.nativeElement);
    this.activeConversation = this.conversations.todayConversations[0];
  }

  openConversation(conversation): void {
    this.activeConversation = conversation;
    this.chatMessageOpened = true;
  }

  deactivateLink(e): void {
    jQuery(e.currentTarget).removeClass('active').find('.badge').remove();
  }

  enableSwipeCollapsing(): void {
    let $chatContainer = jQuery('layout');
    let chatSidebarSwipe = new Hammer(document.getElementById('content-wrap'));

    chatSidebarSwipe.on('swipeleft', () => {
      if ($chatContainer.is('.nav-collapsed')) {
        $chatContainer.addClass('chat-sidebar-opened');
      }
    });

    chatSidebarSwipe.on('swiperight', () => {
      setTimeout(() => {
        if ($chatContainer.is('.chat-sidebar-opened')) {
          $chatContainer.removeClass('chat-sidebar-opened');
        }
      });
    });
  }

  ngOnInit(): void {
    jQuery('layout').addClass('chat-sidebar-container');

    if ('ontouchstart' in window) {
      this.enableSwipeCollapsing();
    }
  }

}
