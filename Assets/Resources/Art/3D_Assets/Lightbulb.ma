//Maya ASCII 2017ff05 scene
//Name: Lightbulb.ma
//Last modified: Mon, Oct 02, 2017 04:06:10 PM
//Codeset: 1252
requires maya "2017ff05";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2017";
fileInfo "version" "2017";
fileInfo "cutIdentifier" "201706020738-1017329";
fileInfo "osv" "Microsoft Windows 8 Enterprise Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "D7A081A4-4FB2-5A4B-1298-7F93A8337C03";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 8.0220558958921622 1.2695215650404013 -0.29298820439774098 ;
	setAttr ".r" -type "double3" -0.9383527295302293 91.399999999991905 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "352AE34B-481D-5A68-A872-EEA747AD4147";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 8.6937559947314416;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "3AE098F2-4B97-0E1F-044D-C19D2FD3F3EB";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "537FE895-451D-B697-1B50-8C8605809607";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "95CBE469-4F1D-A80C-2478-5487F4476A5C";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "F4E60C03-48CA-502D-2CEE-9681ABA2F268";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "B3C7D06D-4617-9A05-2458-BABB689F2040";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "7FD43F22-4CCF-2DEA-00CC-F5B3FB92797C";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "Lightbulb";
	rename -uid "EFECF7D0-4C9E-7AE2-D0EC-94A9194DDD13";
createNode mesh -n "LightbulbShape" -p "Lightbulb";
	rename -uid "21694E80-461B-4199-65D8-DF8FC2944A6C";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50000005960464478 0.90000015497207642 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 482 ".pt";
	setAttr ".pt[361]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[362]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[363]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[364]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[365]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[366]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[367]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[368]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[369]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[370]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[371]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[372]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[373]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[374]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[375]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[376]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[377]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[378]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[379]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[380]" -type "float3" 0 -0.009297315 0 ;
	setAttr ".pt[381]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[382]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[383]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[384]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[385]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[386]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[387]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[388]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[389]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[390]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[391]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[392]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[393]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[394]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[395]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[396]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[397]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[398]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[399]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[400]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[401]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[402]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[403]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[404]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[405]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[406]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[407]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[408]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[409]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[410]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[411]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[412]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[413]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[414]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[415]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[416]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[417]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[418]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[419]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[420]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[421]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[422]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[423]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[424]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[425]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[426]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[427]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[428]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[429]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[430]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[431]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[432]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[433]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[434]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[435]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[436]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[437]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[438]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[439]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[440]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[441]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[442]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[443]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[444]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[445]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[446]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[447]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[448]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[449]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[450]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[451]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[452]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[453]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[454]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[455]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[456]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[457]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[458]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[459]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[460]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[461]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[462]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[463]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[464]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[465]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[466]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[467]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[468]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[469]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[470]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[471]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[472]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[473]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[474]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[475]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[476]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[477]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[478]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[479]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[480]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[481]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[482]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[483]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[484]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[485]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[486]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[487]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[488]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[489]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[490]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[491]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[492]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[493]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[494]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[495]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[496]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[497]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[498]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[499]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[500]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[501]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[502]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[503]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[504]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[505]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[506]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[507]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[508]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[509]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[510]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[511]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[512]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[513]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[514]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[515]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[516]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[517]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[518]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[519]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[520]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[521]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[522]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[523]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[524]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[525]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[526]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[527]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[528]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[529]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[530]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[531]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[532]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[533]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[534]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[535]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[536]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[537]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[538]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[539]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[540]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[541]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[542]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[543]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[544]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[545]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[546]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[547]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[548]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[549]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[550]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[551]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[552]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[553]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[554]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[555]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[556]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[557]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[558]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[559]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[560]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[561]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[562]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[563]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[564]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[565]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[566]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[567]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[568]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[569]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[570]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[571]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[572]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[573]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[574]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[575]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[576]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[577]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[578]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[579]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[580]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[581]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[582]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[583]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[584]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[585]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[586]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[587]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[588]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[589]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[590]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[591]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[592]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[593]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[594]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[595]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[596]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[597]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[598]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[599]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[600]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[601]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[602]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[603]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[604]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[605]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[606]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[607]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[608]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[609]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[610]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[611]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[612]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[613]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[614]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[615]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[616]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[617]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[618]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[619]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[620]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[621]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[622]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[623]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[624]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[625]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[626]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[627]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[628]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[629]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[630]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[631]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[632]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[633]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[634]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[635]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[636]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[637]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[638]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[639]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[640]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[641]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[642]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[643]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[644]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[645]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[646]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[647]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[648]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[649]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[650]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[651]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[652]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[653]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[654]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[655]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[656]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[657]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[658]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[659]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[660]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[661]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[662]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[663]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[664]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[665]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[666]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[667]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[668]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[669]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[670]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[671]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[672]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[673]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[674]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[675]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[676]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[677]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[678]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[679]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[680]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[681]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[682]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[683]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[684]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[685]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[686]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[687]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[688]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[689]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[690]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[691]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[692]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[693]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[694]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[695]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[696]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[697]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[698]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[699]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[700]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[701]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[702]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[703]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[704]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[705]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[706]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[707]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[708]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[709]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[710]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[711]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[712]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[713]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[714]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[715]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[716]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[717]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[718]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[719]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[720]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[721]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[722]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[723]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[724]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[725]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[726]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[727]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[728]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[729]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[730]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[731]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[732]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[733]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[734]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[735]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[736]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[737]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[738]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[739]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[740]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[741]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[742]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[743]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[744]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[745]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[746]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[747]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[748]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[749]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[750]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[751]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[752]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[753]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[754]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[755]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[756]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[757]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[758]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[759]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[760]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[761]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[762]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[763]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[764]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[765]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[766]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[767]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[768]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[769]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[770]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[771]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[772]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[773]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[774]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[775]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[776]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[777]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[778]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[779]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[780]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[781]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[782]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[783]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[784]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[785]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[786]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[787]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[788]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[789]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[790]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[791]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[792]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[793]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[794]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[795]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[796]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[797]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[798]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[799]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[800]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[801]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[802]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[803]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[804]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[805]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[806]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[807]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[808]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[809]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[810]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[811]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[812]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[813]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[814]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[815]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[816]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[817]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[818]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[819]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[820]" -type "float3" 0 -0.059542313 0 ;
	setAttr ".pt[821]" -type "float3" -0.028562959 -0.058300078 0.009280608 ;
	setAttr ".pt[822]" -type "float3" -0.024297077 -0.058300078 0.0176528 ;
	setAttr ".pt[823]" -type "float3" -9.0488337e-009 -0.060784549 -6.827761e-009 ;
	setAttr ".pt[824]" -type "float3" -0.017652867 -0.058300078 0.024297064 ;
	setAttr ".pt[825]" -type "float3" -0.0092806807 -0.058300078 0.028562928 ;
	setAttr ".pt[826]" -type "float3" -8.3417495e-009 -0.058300078 0.030032787 ;
	setAttr ".pt[827]" -type "float3" 0.0092806593 -0.058300078 0.028562905 ;
	setAttr ".pt[828]" -type "float3" 0.017652849 -0.058300078 0.024297064 ;
	setAttr ".pt[829]" -type "float3" 0.024297042 -0.058300078 0.017652825 ;
	setAttr ".pt[830]" -type "float3" 0.028562931 -0.058300078 0.0092806797 ;
	setAttr ".pt[831]" -type "float3" 0.030032838 -0.058300078 -3.7852357e-009 ;
	setAttr ".pt[832]" -type "float3" 0.028562924 -0.058300078 -0.0092806723 ;
	setAttr ".pt[833]" -type "float3" 0.024297068 -0.058300078 -0.017652825 ;
	setAttr ".pt[834]" -type "float3" 0.017652862 -0.058300078 -0.024297068 ;
	setAttr ".pt[835]" -type "float3" 0.0092806537 -0.058300078 -0.028562905 ;
	setAttr ".pt[836]" -type "float3" -1.5246247e-008 -0.058300078 -0.030032787 ;
	setAttr ".pt[837]" -type "float3" -0.0092806881 -0.058300078 -0.028562905 ;
	setAttr ".pt[838]" -type "float3" -0.017652867 -0.058300078 -0.024297033 ;
	setAttr ".pt[839]" -type "float3" -0.024297085 -0.058300078 -0.017652823 ;
	setAttr ".pt[840]" -type "float3" -0.02856295 -0.058300078 -0.0092806425 ;
	setAttr ".pt[841]" -type "float3" -0.030032838 -0.058300078 -1.4344052e-008 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "835E9D25-4AC8-A940-0CE0-C887F0BA4579";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "225C9F77-4A1A-F4D4-CDE5-5499F6C5D8B0";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "5FA51D07-4F26-7C8C-F926-BAA899070388";
createNode displayLayerManager -n "layerManager";
	rename -uid "8C24F740-481E-C553-0B10-C6A408D01BFE";
createNode displayLayer -n "defaultLayer";
	rename -uid "653248A5-45CC-FFCA-771D-6493522A4C46";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "64B628C8-4A18-DB53-A525-C9B8B931DDAA";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "16C9BB43-4BC1-4B0D-5B5D-46A7C4C01EFC";
	setAttr ".g" yes;
createNode polySphere -n "polySphere1";
	rename -uid "ED459FCC-4D2C-AC2B-5F8F-458C69446B6B";
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "21C3E985-4F94-AB9A-98F5-91823D0C973C";
	setAttr ".ics" -type "componentList" 2 "f[300:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -5.9604645e-008 0.90450853 -1.1920929e-007 ;
	setAttr ".rs" 54391;
	setAttr ".lt" -type "double3" 0 -1.3877787807814457e-017 0.5236704607576943 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.58778536319732666 0.80901700258255005 -0.58778554201126099 ;
	setAttr ".cbx" -type "double3" 0.58778524398803711 1 0.58778530359268188 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "EAF7DC73-45D9-497A-BBD0-BFB669B8688A";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -5.9604645e-008 1.4857754 2.9802322e-008 ;
	setAttr ".rs" 58429;
	setAttr ".lt" -type "double3" -1.111307226797642e-016 -3.1225022567582528e-017 0.11621222918660519 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.47453713417053223 1.4478802680969238 -0.47453701496124268 ;
	setAttr ".cbx" -type "double3" 0.47453701496124268 1.5236704349517822 0.47453707456588745 ;
createNode polyTweak -n "polyTweak1";
	rename -uid "3021B200-4AD5-E9D8-A31B-C683AB12FFE0";
	setAttr ".uopa" yes;
	setAttr -s 83 ".tk";
	setAttr ".tk[280]" -type "float3" 0.056694031 0 -0.018420992 ;
	setAttr ".tk[281]" -type "float3" 0.048226822 0 -0.035038818 ;
	setAttr ".tk[282]" -type "float3" 0.035038833 0 -0.048226796 ;
	setAttr ".tk[283]" -type "float3" 0.018421009 0 -0.056694008 ;
	setAttr ".tk[284]" -type "float3" 7.537321e-009 0 -0.059611596 ;
	setAttr ".tk[285]" -type "float3" -0.018420992 0 -0.056694001 ;
	setAttr ".tk[286]" -type "float3" -0.03503881 0 -0.048226785 ;
	setAttr ".tk[287]" -type "float3" -0.048226789 0 -0.035038814 ;
	setAttr ".tk[288]" -type "float3" -0.05669399 0 -0.018420983 ;
	setAttr ".tk[289]" -type "float3" -0.059611592 0 1.2562202e-008 ;
	setAttr ".tk[290]" -type "float3" -0.05669399 0 0.018421009 ;
	setAttr ".tk[291]" -type "float3" -0.048226789 0 0.035038833 ;
	setAttr ".tk[292]" -type "float3" -0.035038814 0 0.0482268 ;
	setAttr ".tk[293]" -type "float3" -0.018420989 0 0.056694008 ;
	setAttr ".tk[294]" -type "float3" 5.7607581e-009 0 0.059611596 ;
	setAttr ".tk[295]" -type "float3" 0.018420996 0 0.056694008 ;
	setAttr ".tk[296]" -type "float3" 0.03503881 0 0.048226796 ;
	setAttr ".tk[297]" -type "float3" 0.0482268 0 0.035038821 ;
	setAttr ".tk[298]" -type "float3" 0.05669399 0 0.018421007 ;
	setAttr ".tk[299]" -type "float3" 0.059611592 0 1.2562202e-008 ;
	setAttr ".tk[300]" -type "float3" 0.12714498 0 -0.041311894 ;
	setAttr ".tk[301]" -type "float3" 0.108156 0 -0.078579858 ;
	setAttr ".tk[302]" -type "float3" 0.078579873 0 -0.10815595 ;
	setAttr ".tk[303]" -type "float3" 0.041311942 0 -0.12714496 ;
	setAttr ".tk[304]" -type "float3" 1.35567e-008 0 -0.13368815 ;
	setAttr ".tk[305]" -type "float3" -0.041311916 0 -0.12714496 ;
	setAttr ".tk[306]" -type "float3" -0.078579858 0 -0.10815589 ;
	setAttr ".tk[307]" -type "float3" -0.10815591 0 -0.078579813 ;
	setAttr ".tk[308]" -type "float3" -0.12714495 0 -0.041311849 ;
	setAttr ".tk[309]" -type "float3" -0.13368812 0 2.71134e-008 ;
	setAttr ".tk[310]" -type "float3" -0.12714495 0 0.041311942 ;
	setAttr ".tk[311]" -type "float3" -0.10815589 0 0.078579858 ;
	setAttr ".tk[312]" -type "float3" -0.078579813 0 0.10815594 ;
	setAttr ".tk[313]" -type "float3" -0.041311894 0 0.12714496 ;
	setAttr ".tk[314]" -type "float3" 9.5724921e-009 0 0.13368815 ;
	setAttr ".tk[315]" -type "float3" 0.04131192 0 0.12714496 ;
	setAttr ".tk[316]" -type "float3" 0.078579843 0 0.10815595 ;
	setAttr ".tk[317]" -type "float3" 0.10815591 0 0.078579843 ;
	setAttr ".tk[318]" -type "float3" 0.12714495 0 0.041311935 ;
	setAttr ".tk[319]" -type "float3" 0.13368812 0 2.71134e-008 ;
	setAttr ".tk[321]" -type "float3" -0.23278241 1.9877797e-008 0.0756355 ;
	setAttr ".tk[322]" -type "float3" -0.19801663 1.9877797e-008 0.1438674 ;
	setAttr ".tk[323]" -type "float3" -0.10045692 -1.1667971e-008 0.072986268 ;
	setAttr ".tk[324]" -type "float3" -0.11809422 -1.1667971e-008 0.038371108 ;
	setAttr ".tk[325]" -type "float3" -0.14386736 1.9877797e-008 0.19801663 ;
	setAttr ".tk[326]" -type "float3" -0.072986215 -1.1667971e-008 0.10045695 ;
	setAttr ".tk[327]" -type "float3" -0.075635567 -1.9877801e-008 0.23278241 ;
	setAttr ".tk[328]" -type "float3" -0.03837112 -1.1667971e-008 0.11809421 ;
	setAttr ".tk[329]" -type "float3" -6.3579799e-009 -1.9877801e-008 0.24476187 ;
	setAttr ".tk[330]" -type "float3" -4.2661985e-009 -1.1667971e-008 0.12417155 ;
	setAttr ".tk[331]" -type "float3" 0.075635567 1.9877797e-008 0.23278232 ;
	setAttr ".tk[332]" -type "float3" 0.03837112 -1.1667971e-008 0.11809418 ;
	setAttr ".tk[333]" -type "float3" 0.14386736 -1.9877801e-008 0.19801655 ;
	setAttr ".tk[334]" -type "float3" 0.072986208 -1.1667971e-008 0.10045689 ;
	setAttr ".tk[335]" -type "float3" 0.19801657 -1.9877801e-008 0.14386733 ;
	setAttr ".tk[336]" -type "float3" 0.10045688 -1.1667971e-008 0.072986208 ;
	setAttr ".tk[337]" -type "float3" 0.23278229 -1.9877801e-008 0.075635552 ;
	setAttr ".tk[338]" -type "float3" 0.11809418 -1.1667971e-008 0.038371123 ;
	setAttr ".tk[339]" -type "float3" 0.24476185 1.9877797e-008 -4.6625203e-008 ;
	setAttr ".tk[340]" -type "float3" 0.12417154 -1.1667971e-008 3.5942533e-009 ;
	setAttr ".tk[341]" -type "float3" 0.23278235 1.9877797e-008 -0.075635664 ;
	setAttr ".tk[342]" -type "float3" 0.11809418 1.1667971e-008 -0.038371123 ;
	setAttr ".tk[343]" -type "float3" 0.19801657 1.9877797e-008 -0.14386746 ;
	setAttr ".tk[344]" -type "float3" 0.10045688 -1.1667971e-008 -0.072986186 ;
	setAttr ".tk[345]" -type "float3" 0.14386733 1.9877797e-008 -0.1980166 ;
	setAttr ".tk[346]" -type "float3" 0.072986186 -1.1667971e-008 -0.10045688 ;
	setAttr ".tk[347]" -type "float3" 0.075635545 1.9877797e-008 -0.23278239 ;
	setAttr ".tk[348]" -type "float3" 0.038371105 1.1667971e-008 -0.11809418 ;
	setAttr ".tk[349]" -type "float3" -1.0066798e-008 1.9877797e-008 -0.24476187 ;
	setAttr ".tk[350]" -type "float3" -1.2151959e-008 1.1667971e-008 -0.12417155 ;
	setAttr ".tk[351]" -type "float3" -0.075635567 1.9877797e-008 -0.23278241 ;
	setAttr ".tk[352]" -type "float3" -0.038371123 1.1667971e-008 -0.11809417 ;
	setAttr ".tk[353]" -type "float3" -0.14386736 1.9877797e-008 -0.19801657 ;
	setAttr ".tk[354]" -type "float3" -0.072986208 -1.1667971e-008 -0.10045687 ;
	setAttr ".tk[355]" -type "float3" -0.19801657 1.9877797e-008 -0.14386736 ;
	setAttr ".tk[356]" -type "float3" -0.10045689 1.1667971e-008 -0.072986193 ;
	setAttr ".tk[357]" -type "float3" -0.23278235 1.9877797e-008 -0.075635575 ;
	setAttr ".tk[358]" -type "float3" -0.11809418 1.1667971e-008 -0.038371105 ;
	setAttr ".tk[359]" -type "float3" -0.24476185 -1.9877801e-008 -9.5899516e-008 ;
	setAttr ".tk[360]" -type "float3" -0.12417154 -1.1667971e-008 -1.5108277e-008 ;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "5A6C5740-4668-2AF7-5887-6B99013F1FD5";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -5.9604645e-008 1.6003072 2.9802322e-008 ;
	setAttr ".rs" 63634;
	setAttr ".lt" -type "double3" 6.8765522789893119e-017 -1.0408340855860843e-017 0.03671388560710602 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.47377395629882813 1.5607316493988037 -0.47377383708953857 ;
	setAttr ".cbx" -type "double3" 0.47377383708953857 1.6398826837539673 0.47377389669418335 ;
createNode polyTweak -n "polyTweak2";
	rename -uid "64A4D539-49FA-604B-FD33-36A24D06738C";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[381]" -type "float3" -0.026788667 1.0251921e-008 0.0087041575 ;
	setAttr ".tk[382]" -type "float3" -0.022787794 1.0251921e-008 0.01655631 ;
	setAttr ".tk[385]" -type "float3" -0.016556302 1.0251921e-008 0.022787809 ;
	setAttr ".tk[387]" -type "float3" -0.0087041641 3.4173071e-009 0.02678865 ;
	setAttr ".tk[389]" -type "float3" -3.3056164e-009 -1.0251923e-008 0.028167255 ;
	setAttr ".tk[391]" -type "float3" 0.0087041603 -3.4173067e-009 0.026788654 ;
	setAttr ".tk[393]" -type "float3" 0.016556302 1.0251921e-008 0.022787791 ;
	setAttr ".tk[395]" -type "float3" 0.022787791 3.4173071e-009 0.016556295 ;
	setAttr ".tk[397]" -type "float3" 0.02678865 1.0251921e-008 0.0087041678 ;
	setAttr ".tk[399]" -type "float3" 0.028167255 1.0251921e-008 5.5006497e-009 ;
	setAttr ".tk[401]" -type "float3" 0.02678865 3.4173071e-009 -0.0087041641 ;
	setAttr ".tk[403]" -type "float3" 0.022787787 1.0251921e-008 -0.016556291 ;
	setAttr ".tk[405]" -type "float3" 0.016556295 3.4173071e-009 -0.022787791 ;
	setAttr ".tk[407]" -type "float3" 0.0087041585 3.4173071e-009 -0.026788661 ;
	setAttr ".tk[409]" -type "float3" -5.7227658e-009 3.4173071e-009 -0.028167255 ;
	setAttr ".tk[411]" -type "float3" -0.0087041678 3.4173071e-009 -0.02678865 ;
	setAttr ".tk[413]" -type "float3" -0.016556302 3.4173071e-009 -0.022787787 ;
	setAttr ".tk[415]" -type "float3" -0.022787793 1.0251921e-008 -0.016556302 ;
	setAttr ".tk[417]" -type "float3" -0.026788661 3.4173071e-009 -0.0087041603 ;
	setAttr ".tk[419]" -type "float3" -0.028167255 3.4173071e-009 -4.4423301e-009 ;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "606C5792-46EB-6790-17A8-59AB480C777C";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n"
		+ "            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n"
		+ "            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n"
		+ "            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n"
		+ "            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n"
		+ "        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n"
		+ "            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n"
		+ "            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n"
		+ "            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1317\n            -height 710\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n"
		+ "            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"0\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n"
		+ "            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n"
		+ "            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n"
		+ "            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n"
		+ "                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n"
		+ "                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n"
		+ "                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n"
		+ "                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n"
		+ "                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n"
		+ "                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n"
		+ "                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n"
		+ "                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n"
		+ "                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n"
		+ "                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"\"\n"
		+ "\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1317\\n    -height 710\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1317\\n    -height 710\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "03EF2AD7-46C7-0885-BA6B-77A53A4AA924";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "5A978FE4-48DF-B8AD-B3E6-A6A9A46ECED0";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -5.9604645e-008 1.6363528 4.4703484e-008 ;
	setAttr ".rs" 54451;
	setAttr ".lt" -type "double3" -7.4294953869569191e-017 -4.6837533851373792e-017 
		0.034154704294959502 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.48346871137619019 1.59610915184021 -0.48346856236457825 ;
	setAttr ".cbx" -type "double3" 0.48346859216690063 1.6765965223312378 0.48346865177154541 ;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "19AB6A82-4808-B44B-4F87-6A8A18AEED4E";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -7.4505806e-008 1.669888 5.9604645e-008 ;
	setAttr ".rs" 64342;
	setAttr ".lt" -type "double3" -1.3786985875868796e-016 -2.5587171270657905e-017 
		0.031106073085749492 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49247312545776367 1.6290247440338135 -0.49247291684150696 ;
	setAttr ".cbx" -type "double3" 0.49247297644615173 1.7107511758804321 0.49247303605079651 ;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "75A02A8B-4912-DC38-8D85-529F9F335914";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -8.9406967e-008 1.7004315 5.9604645e-008 ;
	setAttr ".rs" 62126;
	setAttr ".lt" -type "double3" 9.9204498782423656e-017 2.5153490401663703e-017 0.047849714563301372 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.47900703549385071 1.6607973575592041 -0.47900682687759399 ;
	setAttr ".cbx" -type "double3" 0.47900685667991638 1.7400655746459961 0.47900694608688354 ;
createNode polyTweak -n "polyTweak3";
	rename -uid "1D81A7B2-48BA-0590-88F7-5A945020D8D6";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[441:481]" -type "float3"  -0.020594845 0.0017917553
		 0.0066916635 -0.017519012 0.0017917553 0.012728314 -0.0098047145 -0.00080894382 0.0071235192
		 -0.011526141 -0.0008089387 0.0037450588 -0.012728308 0.0017917553 0.017519021 -0.0071235411
		 -0.0008089387 0.0098047033 -0.0066916705 0.0017917503 0.020594832 -0.0037450718 -0.0008089387
		 0.011526138 -4.3982573e-009 0.0017917401 0.02165468 -3.8515866e-009 -0.0008089387
		 0.012119285 0.0066916668 0.0017917454 0.02059483 0.0037450648 -0.0008089387 0.011526127
		 0.012728306 0.0017917553 0.01751901 0.0071235341 -0.0008089387 0.009804707 0.017519008
		 0.0017917503 0.012728306 0.0098047052 -0.00080894382 0.0071235262 0.02059483 0.0017917553
		 0.0066916705 0.011526127 -0.0008089387 0.0037450704 0.021654688 0.0017917553 5.4581695e-009
		 0.012119285 -0.0008089387 1.5829492e-009 0.02059483 0.0017917503 -0.0066916696 0.011526125
		 -0.0008089387 -0.0037450704 0.017519008 0.0017917553 -0.012728302 0.009804708 -0.0008089387
		 -0.0071235327 0.012728302 0.0017917503 -0.017519007 0.0071235341 -0.0008089387 -0.0098047107
		 0.0066916626 0.0017917503 -0.020594832 0.0037450639 -0.0008089387 -0.011526125 -6.0699472e-009
		 0.0017917503 -0.02165468 -5.0405964e-009 -0.00080894382 -0.012119275 -0.0066916714
		 0.0017917503 -0.020594828 -0.0037450748 -0.0008089387 -0.011526123 -0.012728308 0.0017917503
		 -0.017519007 -0.0071235411 -0.0008089387 -0.0098046996 -0.01751901 0.0017917553 -0.012728306
		 -0.0098047126 -0.00080894382 -0.0071235192 -0.020594835 0.0017917503 -0.0066916635
		 -0.011526134 -0.0008089387 -0.0037450595 -0.021654688 0.0017917503 -1.2185213e-009
		 -0.012119289 -0.0008089387 -4.2915671e-009 -3.4062448e-009 -0.0017917553 -2.6388198e-009;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "30F2633B-4B48-9C59-3AC9-E3B2CE457331";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.0430813e-007 1.747418 5.9604645e-008 ;
	setAttr ".rs" 39804;
	setAttr ".lt" -type "double3" 1.611395478856581e-017 -6.6786853825107073e-017 0.019895931553024125 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49158680438995361 1.706920862197876 -0.49158653616905212 ;
	setAttr ".cbx" -type "double3" 0.4915865957736969 1.7879152297973633 0.49158665537834167 ;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "224921FB-4A35-439A-7113-AC9FE8307312";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.0430813e-007 1.7669566 5.9604645e-008 ;
	setAttr ".rs" 53459;
	setAttr ".lt" -type "double3" -6.9626108264303488e-017 -8.6736173798840355e-019 
		0.016550267201678452 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49680668115615845 1.7261021137237549 -0.49680641293525696 ;
	setAttr ".cbx" -type "double3" 0.49680647253990173 1.8078111410140991 0.49680653214454651 ;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "633FD89B-425D-4C5D-8B71-2C8C1D2314C3";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.7832102 5.9604645e-008 ;
	setAttr ".rs" 47631;
	setAttr ".lt" -type "double3" 1.3552527156068805e-017 3.8597597340483958e-017 0.024809927640191916 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.5011451244354248 1.7420587539672852 -0.50114482641220093 ;
	setAttr ".cbx" -type "double3" 0.5011448860168457 1.8243614435195923 0.50114494562149048 ;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "2958CE34-4DB3-24DA-3D39-51AEF7DC162A";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.8075758 5.9604645e-008 ;
	setAttr ".rs" 36165;
	setAttr ".lt" -type "double3" -1.0954507700250415e-016 8.2833045977892539e-017 0.020657620297293157 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.48647403717041016 1.7677148580551147 -0.48647376894950867 ;
	setAttr ".cbx" -type "double3" 0.48647379875183105 1.847436785697937 0.48647388815879822 ;
createNode polyTweak -n "polyTweak4";
	rename -uid "D6F04C4C-470B-2D97-B113-04AFB1661ACA";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[521:561]" -type "float3"  -0.020134 0.0017346479 0.006541925
		 -0.017126998 0.0017346479 0.012443494 -0.0097128535 -0.00075241795 0.0070567806 -0.011418154
		 -0.00075241295 0.0037099677 -0.012443494 0.0017346479 0.017127002 -0.0070568006 -0.00075241295
		 0.0097128442 -0.0065419367 0.0017346427 0.020133983 -0.0037099868 -0.00075241295
		 0.011418145 -5.8209437e-009 0.0017346325 0.021170119 -4.8616706e-009 -0.00075241295
		 0.012005736 0.0065419301 0.0017346377 0.02013398 0.003709978 -0.00075241295 0.011418137
		 0.012443485 0.0017346479 0.017126992 0.0070567932 -0.00075241295 0.0097128442 0.017126989
		 0.0017346427 0.012443485 0.0097128423 -0.00075241795 0.0070567853 0.020133983 0.0017346479
		 0.0065419325 0.011418138 -0.00075241295 0.0037099801 0.021170124 0.0017346479 5.7020006e-009
		 0.012005737 -0.00075241295 2.7604816e-009 0.020133981 0.0017346427 -0.0065419301
		 0.011418133 -0.00075241295 -0.0037099803 0.017126989 0.0017346479 -0.012443483 0.0097128442
		 -0.00075241295 -0.0070567904 0.012443483 0.0017346427 -0.017126989 0.007056796 -0.00075241295
		 -0.0097128497 0.0065419241 0.0017346427 -0.020133989 0.0037099761 -0.00075241295
		 -0.011418135 -7.3793451e-009 0.0017346427 -0.021170119 -6.2095999e-009 -0.00075241795
		 -0.012005725 -0.0065419357 0.0017346427 -0.02013398 -0.0037099896 -0.00075241295
		 -0.011418133 -0.012443493 0.0017346427 -0.017126989 -0.0070568002 -0.00075241295
		 -0.0097128395 -0.017126998 0.0017346479 -0.01244349 -0.0097128507 -0.00075241795
		 -0.0070567811 -0.020133993 0.0017346427 -0.0065419246 -0.011418146 -0.00075241295
		 -0.0037099705 -0.021170124 0.0017346427 1.3108047e-010 -0.012005743 -0.00075241295
		 -4.2975108e-009 -4.243915e-009 -0.0017346479 -3.025284e-009;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	rename -uid "16FF4EF0-4C86-540A-BB8C-D69F2D48F93A";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.8278644 5.9604645e-008 ;
	setAttr ".rs" 48664;
	setAttr ".lt" -type "double3" 1.3593184737537012e-017 1.3444106938820255e-017 0.030061434259018423 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49187982082366943 1.7876342535018921 -0.49187955260276794 ;
	setAttr ".cbx" -type "double3" 0.49187958240509033 1.8680944442749023 0.4918796718120575 ;
createNode polyExtrudeFace -n "polyExtrudeFace12";
	rename -uid "E687BBD8-42B2-5369-F236-6686BB65DC79";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.8573897 7.4505806e-008 ;
	setAttr ".rs" 47256;
	setAttr ".lt" -type "double3" -5.1255657704252222e-017 -2.3852447794681098e-017 
		0.018543084843631104 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49973946809768677 1.816623330116272 -0.49973917007446289 ;
	setAttr ".cbx" -type "double3" 0.49973922967910767 1.8981559276580811 0.49973931908607483 ;
createNode polyExtrudeFace -n "polyExtrudeFace13";
	rename -uid "504DA359-4D53-ABB9-1B61-DEBA924B50A8";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.8756028 5.9604645e-008 ;
	setAttr ".rs" 45326;
	setAttr ".lt" -type "double3" -8.6329597984158291e-018 -2.0383000842727483e-017 
		0.021259107759691125 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.5045815110206604 1.834506630897522 -0.50458121299743652 ;
	setAttr ".cbx" -type "double3" 0.5045812726020813 1.9166990518569946 0.50458133220672607 ;
createNode polyExtrudeFace -n "polyExtrudeFace14";
	rename -uid "99CC8B4A-4570-0E32-B1D2-69B1772BC3EE";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.8964844 5.9604645e-008 ;
	setAttr ".rs" 56923;
	setAttr ".lt" -type "double3" 4.775910569798647e-017 6.114900252818245e-017 0.018653749601969281 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49101832509040833 1.8565642833709717 -0.49101802706718445 ;
	setAttr ".cbx" -type "double3" 0.49101808667182922 1.9364044666290283 0.491018146276474 ;
createNode polyTweak -n "polyTweak5";
	rename -uid "2D3BB14C-4418-392B-A100-C7A11AD58B18";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[601:641]" -type "float3"  -0.018174812 0.0015536638
		 0.0059053474 -0.015460415 0.0015536638 0.011232647 -0.0088582318 -0.00065199903 0.0064358665
		 -0.010413487 -0.00065199495 0.0033835354 -0.011232653 0.0015536638 0.015460416 -0.0064358823
		 -0.00065199495 0.0088582262 -0.0059053577 0.0015536592 0.018174797 -0.0033835513
		 -0.00065199495 0.010413478 -5.2420166e-009 0.0015536502 0.019110106 -4.1559889e-009
		 -0.00065199495 0.010949366 0.0059053521 0.0015536547 0.018174792 0.0033835433 -0.00065199495
		 0.01041347 0.011232644 0.0015536638 0.01546041 0.0064358767 -0.00065199495 0.0088582262
		 0.015460407 0.0015536592 0.011232643 0.0088582216 -0.00065199903 0.0064358665 0.018174801
		 0.0015536638 0.0059053525 0.010413474 -0.00065199495 0.0033835429 0.019110113 0.0015536638
		 6.1513017e-009 0.010949372 -0.00065199495 2.0617854e-009 0.018174794 0.0015536592
		 -0.0059053521 0.01041347 -0.00065199495 -0.0033835447 0.015460406 0.0015536638 -0.011232643
		 0.0088582262 -0.00065199495 -0.0064358716 0.011232639 0.0015536592 -0.015460407 0.00643588
		 -0.00065199495 -0.0088582318 0.0059053469 0.0015536592 -0.018174801 0.0033835415
		 -0.00065199495 -0.010413471 -6.8599784e-009 0.0015536592 -0.019110106 -5.6775713e-009
		 -0.00065199903 -0.01094936 -0.0059053572 0.0015536592 -0.018174794 -0.0033835538
		 -0.00065199495 -0.010413469 -0.011232647 0.0015536592 -0.015460405 -0.0064358814
		 -0.00065199495 -0.0088582216 -0.015460415 0.0015536638 -0.011232645 -0.0088582318
		 -0.00065199903 -0.0064358665 -0.018174805 0.0015536592 -0.0059053469 -0.010413481
		 -0.00065199495 -0.0033835364 -0.019110113 0.0015536592 9.5398611e-010 -0.010949374
		 -0.00065199495 -4.3194879e-009 -3.5582359e-009 -0.0015536638 -2.7941265e-009;
createNode polyExtrudeFace -n "polyExtrudeFace15";
	rename -uid "F7454A4F-4620-91F4-40D6-1F8F0272549C";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.9148073 8.9406967e-008 ;
	setAttr ".rs" 36286;
	setAttr ".lt" -type "double3" 3.5006177644125724e-017 8.3266726846886741e-017 0.017831563896147571 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49588122963905334 1.8745565414428711 -0.49588087201118469 ;
	setAttr ".cbx" -type "double3" 0.49588099122047424 1.955058217048645 0.49588105082511902 ;
createNode polyExtrudeFace -n "polyExtrudeFace16";
	rename -uid "6C7C5D07-4D1E-A7EF-72BC-85A3EB3E21D0";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.9323233 8.9406967e-008 ;
	setAttr ".rs" 47203;
	setAttr ".lt" -type "double3" 7.1692868655603981e-017 1.6913553890773869e-017 0.026184568474932772 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.50052613019943237 1.8917567729949951 -0.50052577257156372 ;
	setAttr ".cbx" -type "double3" 0.50052589178085327 1.97288978099823 0.50052595138549805 ;
createNode polyExtrudeFace -n "polyExtrudeFace17";
	rename -uid "60E137D4-4E4E-301B-DC93-B88622149582";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.958045 1.1920929e-007 ;
	setAttr ".rs" 57660;
	setAttr ".lt" -type "double3" 1.7536970139953034e-016 9.5843472047718592e-017 0.020535310617041381 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.50734180212020874 1.9170157909393311 -0.50734138488769531 ;
	setAttr ".cbx" -type "double3" 0.50734156370162964 1.9990743398666382 0.50734162330627441 ;
createNode polyExtrudeFace -n "polyExtrudeFace18";
	rename -uid "27DB936A-415A-52E5-A3A9-209D0A4A1FBC";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 1.9782182 1.1920929e-007 ;
	setAttr ".rs" 62304;
	setAttr ".lt" -type "double3" -7.2885491045338036e-017 1.9949319973733282e-017 0.047300846136354179 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.48974683880805969 1.9386782646179199 -0.48974645137786865 ;
	setAttr ".cbx" -type "double3" 0.48974660038948059 2.0177581310272217 0.48974668979644775 ;
createNode polyTweak -n "polyTweak6";
	rename -uid "BD00754D-430A-7D1F-905F-1E8E7E761794";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[681:721]" -type "float3"  -0.02181186 0.0018516115 0.0070870998
		 -0.018554272 0.0018516115 0.013480472 -0.010726343 -0.00075384462 0.0077931285 -0.012609583
		 -0.00075383956 0.004097092 -0.013480472 0.0018516115 0.018554276 -0.0077931434 -0.00075383956
		 0.010726338 -0.0070871087 0.0018516064 0.021811845 -0.0040971073 -0.00075383956 0.012609575
		 -6.2388685e-009 0.0018515952 0.022934325 -4.6985145e-009 -0.00075383956 0.013258477
		 0.0070871022 0.0018516007 0.021811837 0.004097098 -0.00075383956 0.012609567 0.013480463
		 0.0018516115 0.018554272 0.0077931364 -0.00075383956 0.010726343 0.018554265 0.0018516064
		 0.013480463 0.01072633 -0.00075384462 0.007793129 0.02181185 0.0018516115 0.007087104
		 0.01260957 -0.00075383956 0.0040970985 0.022934334 0.0018516115 1.0037913e-008 0.013258482
		 -0.00075383956 4.2608224e-009 0.021811837 0.0018516064 -0.0070870975 0.012609562
		 -0.00075383956 -0.0040970976 0.018554263 0.0018516115 -0.013480458 0.010726334 -0.00075383956
		 -0.0077931304 0.01348046 0.0018516064 -0.018554259 0.0077931411 -0.00075383956 -0.010726338
		 0.0070870938 0.0018516064 -0.021811845 0.0040970962 -0.00075383956 -0.012609561 -8.3766452e-009
		 0.0018516064 -0.022934325 -6.8254398e-009 -0.00075384462 -0.013258464 -0.0070871059
		 0.0018516064 -0.021811835 -0.0040971111 -0.00075383956 -0.012609561 -0.013480468
		 0.0018516064 -0.018554257 -0.0077931411 -0.00075383956 -0.010726328 -0.018554272
		 0.0018516115 -0.013480463 -0.01072634 -0.00075384462 -0.0077931229 -0.02181185 0.0018516064
		 -0.0070870914 -0.01260958 -0.00075383956 -0.0040970864 -0.022934334 0.0018516064
		 4.8197597e-009 -0.013258485 -0.00075383956 -8.7233643e-010 -3.9956745e-009 -0.0018516117
		 -9.0267668e-011;
createNode polyExtrudeFace -n "polyExtrudeFace19";
	rename -uid "496CCDC3-4C12-B691-625E-C6A44AB6A58A";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 2.0246861 1.1920929e-007 ;
	setAttr ".rs" 61751;
	setAttr ".lt" -type "double3" 7.5460471204991109e-017 6.591949208711867e-017 0.022141028123370599 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.44311684370040894 1.9890515804290771 -0.4431164562702179 ;
	setAttr ".cbx" -type "double3" 0.44311660528182983 2.0603208541870117 0.443116694688797 ;
createNode polyTweak -n "polyTweak7";
	rename -uid "84F63E09-4A6D-9442-FE6D-C4823B6A424A";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[701:741]" -type "float3"  -0.056034699 0.0047381036
		 0.018206775 -0.047665957 0.0047381036 0.034631357 -0.027692921 -0.001895612 0.020120053
		 -0.032555029 -0.0018955858 0.010577741 -0.034631357 0.0047381036 0.047665969 -0.020120088
		 -0.0018955858 0.027692918 -0.018206798 0.0047380896 0.056034684 -0.010577782 -0.0018955858
		 0.032554988 -1.5882527e-008 0.0047380626 0.058918331 -1.1650864e-008 -0.0018955858
		 0.03423031 0.018206786 0.0047380757 0.056034654 0.010577755 -0.0018955858 0.032554977
		 0.034631338 0.0047381036 0.047665957 0.020120069 -0.0018955858 0.027692923 0.047665928
		 0.0047380896 0.034631338 0.027692897 -0.001895612 0.020120053 0.056034688 0.0047381036
		 0.018206788 0.032554988 -0.0018955858 0.010577752 0.058918361 0.0047381036 2.8602214e-008
		 0.034230329 -0.0018955858 1.2515976e-008 0.056034669 0.0047380896 -0.018206771 0.032554965
		 -0.0018955858 -0.010577752 0.047665924 0.0047381036 -0.034631331 0.027692916 -0.0018955858
		 -0.020120064 0.034631331 0.0047380896 -0.04766592 0.020120086 -0.0018955858 -0.027692918
		 0.018206758 0.0047380896 -0.05603468 0.010577752 -0.0018955858 -0.032554965 -2.1689043e-008
		 0.0047380896 -0.058918331 -1.748122e-008 -0.001895612 -0.034230273 -0.018206794 0.0047380896
		 -0.056034651 -0.010577789 -0.0018955858 -0.032554965 -0.034631357 0.0047380896 -0.04766592
		 -0.020120086 -0.0018955858 -0.027692897 -0.047665957 0.0047381036 -0.034631338 -0.02769292
		 -0.001895612 -0.020120034 -0.056034692 0.0047380896 -0.018206753 -0.032555003 -0.0018955858
		 -0.010577722 -0.058918361 0.0047380896 1.2016068e-008 -0.034230329 -0.0018955858
		 -2.3335405e-009 -9.9291313e-009 -0.0047381069 -2.9540581e-010;
createNode polyExtrudeFace -n "polyExtrudeFace20";
	rename -uid "FAF8DAE1-49E6-168F-1A75-C8BBB0A76720";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 2.0464389 1.1920929e-007 ;
	setAttr ".rs" 53373;
	setAttr ".lt" -type "double3" 2.8487412082056629e-017 -6.9388939039072284e-018 0.052371880816831348 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.3865528404712677 2.0154163837432861 -0.38655248284339905 ;
	setAttr ".cbx" -type "double3" 0.3865526020526886 2.0774614810943604 0.38655272126197815 ;
createNode polyTweak -n "polyTweak8";
	rename -uid "A187F7E3-485A-DFCA-A834-50BBDBDD261C";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[721:761]" -type "float3"  -0.059255287 0.0050002383
		 0.019253196 -0.050405543 0.0050002383 0.036621764 -0.029358795 -0.0019823441 0.021330386
		 -0.034513384 -0.0019823082 0.01121404 -0.036621764 0.0050002383 0.050405532 -0.021330418
		 -0.0019823082 0.029358801 -0.01925322 0.0050002025 0.059255265 -0.01121409 -0.0019823082
		 0.034513358 -1.6757181e-008 0.0050001764 0.062304612 -1.2112503e-008 -0.0019823082
		 0.036289442 0.019253206 0.0050002025 0.059255198 0.011214068 -0.0019823082 0.034513328
		 0.036621753 0.0050002383 0.050405547 0.021330399 -0.0019823082 0.029358808 0.050405521
		 0.0050002025 0.036621757 0.029358767 -0.0019823441 0.021330379 0.05925525 0.0050002383
		 0.019253202 0.034513347 -0.0019823082 0.01121406 0.062304635 0.0050002383 2.7777816e-008
		 0.036289468 -0.0019823082 1.5932329e-008 0.059255198 0.0050002025 -0.019253192 0.034513317
		 -0.0019823082 -0.011214066 0.050405521 0.0050002383 -0.036621749 0.029358795 -0.0019823082
		 -0.02133039 0.036621746 0.0050002025 -0.050405513 0.021330414 -0.0019823082 -0.029358801
		 0.019253176 0.0050002025 -0.05925522 0.011214064 -0.0019823082 -0.034513306 -2.2808827e-008
		 0.0050002025 -0.062304612 -1.8334765e-008 -0.0019823441 -0.036289413 -0.019253215
		 0.0050002025 -0.059255183 -0.011214104 -0.0019823082 -0.034513306 -0.036621764 0.0050002025
		 -0.050405506 -0.021330407 -0.0019823082 -0.029358774 -0.050405547 0.0050002383 -0.036621753
		 -0.029358795 -0.0019823441 -0.021330368 -0.059255265 0.0050002025 -0.019253174 -0.03451338
		 -0.0019823082 -0.011214018 -0.062304635 0.0050002025 1.2487085e-008 -0.036289468
		 -0.0019823082 -2.5222611e-009 -1.0184769e-008 -0.0050002383 -3.0678363e-010;
createNode polyExtrudeFace -n "polyExtrudeFace21";
	rename -uid "6068213A-49F8-33B0-8B7F-CBA3D5345CA9";
	setAttr ".ics" -type "componentList" 2 "f[340:359]" "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.1920929e-007 2.0978944 1.4901161e-007 ;
	setAttr ".rs" 38720;
	setAttr ".lt" -type "double3" -1.395910297075087e-016 -2.4286128663675299e-017 0.03745602415511385 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.31180009245872498 2.073005199432373 -0.31179964542388916 ;
	setAttr ".cbx" -type "double3" 0.31179985404014587 2.1227836608886719 0.31179994344711304 ;
createNode polyTweak -n "polyTweak9";
	rename -uid "3FE25CFB-4BEF-1516-C2EA-B6916DB7833B";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[741:781]" -type "float3"  -0.083995096 0.0070498772
		 0.027291657 -0.071450494 0.0070498772 0.051911816 -0.041892715 -0.0027273358 0.030436812
		 -0.049247928 -0.0027273358 0.016001558 -0.051911816 0.0070498772 0.071450509 -0.030436842
		 -0.0027273358 0.041892711 -0.027291689 0.0070498772 0.083995044 -0.016001638 -0.0027273358
		 0.04924788 -2.1045228e-008 0.0070498241 0.088317558 -1.4967116e-008 -0.0027273358
		 0.051782168 0.027291667 0.0070498772 0.083995029 0.016001603 -0.0027273358 0.049247816
		 0.051911805 0.0070498772 0.071450494 0.030436818 -0.0027273358 0.041892726 0.07145045
		 0.0070498772 0.051911805 0.041892681 -0.0027273358 0.030436793 0.083995067 0.0070498772
		 0.027291656 0.04924788 -0.0027273358 0.016001591 0.088317581 0.0070498772 3.4330188e-008
		 0.051782265 -0.0027273358 3.2609947e-008 0.083995029 0.0070498772 -0.02729162 0.049247809
		 -0.0027273358 -0.016001569 0.07145045 0.0070498772 -0.051911771 0.041892704 -0.0027273358
		 -0.030436799 0.051911794 0.0070498772 -0.071450427 0.030436832 -0.0027273358 -0.041892704
		 0.027291615 0.0070498772 -0.083995029 0.016001599 -0.0027273358 -0.049247779 -3.2068918e-008
		 0.0070498772 -0.088317558 -2.5508573e-008 -0.0027273358 -0.051782131 -0.02729168
		 0.0070498772 -0.083994992 -0.016001653 -0.0027273358 -0.049247801 -0.051911812 0.0070498772
		 -0.071450405 -0.030436832 -0.0027273358 -0.041892678 -0.071450494 0.0070498772 -0.051911794
		 -0.041892711 -0.0027273358 -0.030436749 -0.083995074 0.0070498772 -0.027291592 -0.049247898
		 -0.0027273358 -0.016001523 -0.088317581 0.0070498772 3.4227412e-008 -0.051782258
		 -0.0027273358 -1.2268768e-009 -1.3947588e-008 -0.0070498772 7.8120284e-009;
createNode polyExtrudeFace -n "polyExtrudeFace22";
	rename -uid "F25F96B1-4EB5-DB15-B3F9-FBBD1F90555F";
	setAttr ".ics" -type "componentList" 1 "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.2665987e-007 2.1495943 8.9406967e-008 ;
	setAttr ".rs" 34120;
	setAttr ".lt" -type "double3" 1.305701288192504e-018 2.8622937353617317e-017 0.027293299994913887 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.16039499640464783 2.1428790092468262 -0.16039456427097321 ;
	setAttr ".cbx" -type "double3" 0.16039474308490753 2.1563098430633545 0.16039474308490753 ;
createNode polyTweak -n "polyTweak10";
	rename -uid "5E814409-4620-D710-55B9-89B7805A439C";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[761:801]" -type "float3"  -0.047042228 0.0039298227
		 0.015284923 -0.040016487 0.0039298227 0.029073693 -0.02359619 -0.0014875274 0.017143613
		 -0.027739024 -0.0014875274 0.0090129171 -0.029073697 0.0039298227 0.040016517 -0.017143641
		 -0.0014875274 0.023596186 -0.015284957 0.0039298227 0.047042191 -0.0090129636 -0.0014875274
		 0.02773899 -1.0424793e-008 0.0039297892 0.049463078 -7.3636603e-009 -0.0014875274
		 0.029166464 0.015284948 0.0039298227 0.047042172 0.0090129478 -0.0014875274 0.027738977
		 0.029073674 0.0039298227 0.040016491 0.017143624 -0.0014875274 0.023596194 0.040016472
		 0.0039298227 0.029073671 0.023596166 -0.0014875274 0.017143592 0.047042198 0.0039298227
		 0.015284928 0.027738992 -0.0014875274 0.0090129338 0.049463097 0.0039298227 5.9020095e-009
		 0.029166495 -0.0014875274 1.6163618e-008 0.047042172 0.0039298227 -0.015284939 0.027738977
		 -0.0014875274 -0.0090129366 0.040016472 0.0039298227 -0.029073656 0.023596182 -0.0014875274
		 -0.017143609 0.029073671 0.0039298227 -0.040016469 0.017143637 -0.0014875274 -0.023596182
		 0.015284923 0.0039298227 -0.047042172 0.0090129431 -0.0014875274 -0.027738972 -1.7473173e-008
		 0.0039298227 -0.049463078 -1.3775592e-008 -0.0014875274 -0.029166447 -0.015284952
		 0.0039298227 -0.047042169 -0.0090129739 -0.0014875274 -0.027738973 -0.029073685 0.0039298227
		 -0.040016472 -0.017143637 -0.0014875274 -0.023596168 -0.040016491 0.0039298227 -0.029073674
		 -0.023596194 -0.0014875274 -0.017143598 -0.047042206 0.0039298227 -0.015284904 -0.027739011
		 -0.0014875274 -0.0090129049 -0.049463097 0.0039298227 5.5348144e-009 -0.02916649
		 -0.0014875274 -1.0078042e-008 -7.5505824e-009 -0.0039298227 -1.4121436e-009;
createNode polyExtrudeFace -n "polyExtrudeFace23";
	rename -uid "FF708B07-4154-5F0F-B322-53BADB90A251";
	setAttr ".ics" -type "componentList" 1 "f[380:399]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.2665987e-007 2.1768389 9.6857548e-008 ;
	setAttr ".rs" 33537;
	setAttr ".lt" -type "double3" -4.5511080255973557e-018 4.3368086899420177e-018 0.019830305412197099 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.1519157886505127 2.1705222129821777 -0.15191534161567688 ;
	setAttr ".cbx" -type "double3" 0.1519155353307724 2.1831557750701904 0.1519155353307724 ;
createNode polyTweak -n "polyTweak11";
	rename -uid "17FCA48F-43AB-936F-F8AF-6E824F0EBE8B";
	setAttr ".uopa" yes;
	setAttr -s 21 ".tk[801:821]" -type "float3"  -0.010230022 0.00044726336
		 0.003323917 -0.0087021664 0.00044726336 0.0063224789 -3.2474565e-009 -0.00044726336
		 -1.9169861e-009 -0.0063224961 0.00044726336 0.0087021636 -0.0033239396 0.00044726336
		 0.010230009 -3.085856e-009 0.00044726336 0.010756451 0.0033239322 0.00044726336 0.010230006
		 0.0063224891 0.00044726336 0.0087021654 0.0087021533 0.00044726336 0.0063224761 0.010230012
		 0.00044726336 0.0033239308 0.010756467 0.00044726336 4.442593e-009 0.010230006 0.00044726336
		 -0.0033239343 0.0087021627 0.00044726336 -0.0063224826 0.0063224947 0.00044726336
		 -0.0087021608 0.0033239299 0.00044726336 -0.010230006 -5.4471561e-009 0.00044726336
		 -0.010756451 -0.0033239427 0.00044726336 -0.010230001 -0.0063224956 0.00044726336
		 -0.0087021524 -0.0087021673 0.00044726336 -0.0063224807 -0.010230016 0.00044726336
		 -0.0033239229 -0.010756467 0.00044726336 -5.1806199e-009;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polyExtrudeFace23.out" "LightbulbShape.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polySphere1.out" "polyExtrudeFace1.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace1.mp";
connectAttr "polyTweak1.out" "polyExtrudeFace2.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak1.ip";
connectAttr "polyTweak2.out" "polyExtrudeFace3.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace2.out" "polyTweak2.ip";
connectAttr "polyExtrudeFace3.out" "polyExtrudeFace4.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace4.mp";
connectAttr "polyExtrudeFace4.out" "polyExtrudeFace5.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace5.mp";
connectAttr "polyTweak3.out" "polyExtrudeFace6.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace6.mp";
connectAttr "polyExtrudeFace5.out" "polyTweak3.ip";
connectAttr "polyExtrudeFace6.out" "polyExtrudeFace7.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace7.mp";
connectAttr "polyExtrudeFace7.out" "polyExtrudeFace8.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace8.out" "polyExtrudeFace9.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace9.mp";
connectAttr "polyTweak4.out" "polyExtrudeFace10.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace9.out" "polyTweak4.ip";
connectAttr "polyExtrudeFace10.out" "polyExtrudeFace11.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace11.mp";
connectAttr "polyExtrudeFace11.out" "polyExtrudeFace12.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace12.mp";
connectAttr "polyExtrudeFace12.out" "polyExtrudeFace13.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace13.mp";
connectAttr "polyTweak5.out" "polyExtrudeFace14.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace14.mp";
connectAttr "polyExtrudeFace13.out" "polyTweak5.ip";
connectAttr "polyExtrudeFace14.out" "polyExtrudeFace15.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace15.mp";
connectAttr "polyExtrudeFace15.out" "polyExtrudeFace16.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace16.mp";
connectAttr "polyExtrudeFace16.out" "polyExtrudeFace17.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace17.mp";
connectAttr "polyTweak6.out" "polyExtrudeFace18.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace18.mp";
connectAttr "polyExtrudeFace17.out" "polyTweak6.ip";
connectAttr "polyTweak7.out" "polyExtrudeFace19.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace19.mp";
connectAttr "polyExtrudeFace18.out" "polyTweak7.ip";
connectAttr "polyTweak8.out" "polyExtrudeFace20.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace20.mp";
connectAttr "polyExtrudeFace19.out" "polyTweak8.ip";
connectAttr "polyTweak9.out" "polyExtrudeFace21.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace21.mp";
connectAttr "polyExtrudeFace20.out" "polyTweak9.ip";
connectAttr "polyTweak10.out" "polyExtrudeFace22.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace22.mp";
connectAttr "polyExtrudeFace21.out" "polyTweak10.ip";
connectAttr "polyTweak11.out" "polyExtrudeFace23.ip";
connectAttr "LightbulbShape.wm" "polyExtrudeFace23.mp";
connectAttr "polyExtrudeFace22.out" "polyTweak11.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "LightbulbShape.iog" ":initialShadingGroup.dsm" -na;
// End of Lightbulb.ma
