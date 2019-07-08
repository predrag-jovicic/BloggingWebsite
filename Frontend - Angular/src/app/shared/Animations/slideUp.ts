import { trigger, transition, style, animate } from "@angular/animations";

export let slideUp = trigger('slideUp',[
    transition("void => *",[
      style({transform:'translateY(35px)',opacity:0}),
      animate('0.6s')
    ])
  ]);