<template>
    <Icon :icon="Icons.Spinner" :isSpinning="true" :iconColor="iconColor" />
</template>

<script setup lang="ts">
import { Icons } from "../../models/icons/Icons"
import Icon from "../reusable/IconCard.vue"
import { useStyleStore } from '../../stores/style';

const iconColor = useStyleStore().sectionStyles.other.loading.icon
</script>
