import {
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid,
    LaSquare,
    LaCheckSquare,
    LaEuroSignSolid
} from "oh-vue-icons/icons";

import { IconType } from "oh-vue-icons/types/icons";

// https://oh-vue-icons.js.org/
// Under section "Line Awesome"
export enum Icons {
    LeftArrow,
    RightArrow,
    Gear,
    Currency,
    Spinner,
    CheckedCheckbox,
    EmptyCheckbox
}

export const getIconAsStr = (icon: Icons) => {
    switch (icon) {
        case Icons.Gear:
            return "la-cog-solid"
        case Icons.Spinner:
            return "la-circle-notch-solid"
        case Icons.LeftArrow:
            return "la-angle-left-solid"
        case Icons.RightArrow:
            return "la-angle-right-solid"
        case Icons.CheckedCheckbox:
            return "la-check-square"
        case Icons.EmptyCheckbox:
            return "la-square"
        case Icons.Currency:
            return "la-euro-sign-solid"
        default:
            throw new Error("Icon: " + icon + " has no corresponing component")
    }
}

export const allIcons: IconType[] = [
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid,
    LaSquare,
    LaCheckSquare,
    LaEuroSignSolid
]