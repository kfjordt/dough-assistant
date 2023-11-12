import {
    LaCogSolid,
    LaCircleNotchSolid
} from "oh-vue-icons/icons";

import { IconType } from "oh-vue-icons/types/icons";

export enum Icons {
    Gear,
    Spinner
}

export const getIconAsStr = (icon: Icons) => {
    switch (icon) {
        case Icons.Gear:
            return "la-cog-solid"
        case Icons.Spinner:
            return "la-circle-notch-solid"
        default:
            throw new Error("Icon: " + icon + " has no corresponing component")
    }
}

export const allIcons: IconType[] = [
    LaCogSolid,
    LaCircleNotchSolid
]