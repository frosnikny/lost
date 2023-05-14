INCLUDE globals.ink

-> main

=== main ===
{was_read:
    -> good_luck
- else:
    -> repeat
}
-> END

=== repeat ===
{TURNS() > 2:
    -> serious
- else:
    -> repeat_true
}
-> END

=== serious ===
Ты серьёзно? #speaker:Дуб #portrait:tree_skeptical #aud_interloc:merchant
    * Да. #speaker:Player #player:player_thoughtfull #aud_player:player_yep
        Соболезную. #speaker:Дуб #portrait:tree_contempt #aud_interloc:merchant
        ~ was_oak_angry = false
        ~ was_read = true
        -> DONE
    * Нет. #speaker:Player #player:player_smile #aud_player:player_hmpf
        Пшёл отсюда! #speaker:Дуб #portrait:tree_angry #aud_interloc:merchant
        ~ was_oak_angry = true
        ~ was_read = true
        -> DONE
    * -> DONE
-> END

=== repeat_true ===
... #speaker:Дуб #portrait:tree_ignore #aud_interloc:merchant
    + Здравствуй, Дуб! #speaker:Player #player:player_big_smile #aud_player:player_hey
        -> serious
    + ... #speaker:Player #player:player_look #aud_player:player_hmpf
        -> repeat
-> END

=== good_luck ===
Удачи. #speaker:Дуб #portrait:tree_skeptical #aud_interloc:merchant
-> END