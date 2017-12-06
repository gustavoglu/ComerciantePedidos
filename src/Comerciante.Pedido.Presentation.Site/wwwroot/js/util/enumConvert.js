function referenciaTipoConvert(numeroEnum) {

    switch (numeroEnum) {
        case 1:
            return "RovitexTeen";
            break;
        case 2:
            return "Rovitex";
            break;
        case 3:
            return "Endless";
            break;
        case 4:
            return "Outros";
            break;
        default:
            return "Outros";
    }
}